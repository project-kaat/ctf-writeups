#!/usr/bin/python3

import sys

outstr = ""

def xor(bits):

    ret = ""

    ret += str(int(bits[0]) ^ 0)
    ret += str(int(bits[1]) ^ 1)
    ret += str(int(bits[2]) ^ 0)
    ret += str(int(bits[3]) ^ 1)

    return ret

with open(sys.argv[1], "r") as inFile:

    for line in inFile.readlines():

        line = line.strip()

        part1 = line[0:4]
        part2 = line[4:8]

        outstr += chr(int(xor(part1) + xor(part2),2))

print(outstr)
