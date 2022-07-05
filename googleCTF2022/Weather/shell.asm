mov r0, 0                   ; 78 0

mov FLAGROM_ADDR, r0        ; 88 ee
mov A, FLAGROM_DATA         ; e5 ef
mov SERIAL_OUT_DATA, A      ; f5 f2
inc r0                      ; 08
cjne r0, 256, 0xf7          ; b8 ff f7
