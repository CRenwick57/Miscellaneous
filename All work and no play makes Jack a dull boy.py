import sys
import time
from random import randint, shuffle

s = 'All work and no play makes Jack a dull boy'
mistakes = {
    'A':list('QWSXZ|'),
    'l':list('op;.,k'),
    ' ':list('xcvbnm,'),
    'w':list('23esaq'),
    'o':list('90plki'),
    'r':list('45tfde'),
    'k':list('iol,mj'),
    'a':list('qwsxz'),
    'n':list('bhjm '),
    'd':list('erfcxs'),
    'p':list('0-[;lo'),
    'y':list('67ujhgt'),
    'm':list('njk, '),
    'e':list('34rdsw'),
    's':list('wedxza'),
    'J':list('UIKMNH'),
    'c':list('xdfv '),
    'u':list('78ijhy'),
    'b':list('vghn ')
    }

while True:
    for c in s:
        waitTime = randint(1,10)
        waitTime/= 100.0
        waitTime+=0.05
        time.sleep(waitTime)
        err = randint(1,100)
        if err is 13:
            shuffle(mistakes[c])
            sys.stdout.write(mistakes[c][0])
            time.sleep(waitTime)
            sys.stdout.write('\b')
            time.sleep(waitTime)
        sys.stdout.write(c)
    sys.stdout.write('\n')
