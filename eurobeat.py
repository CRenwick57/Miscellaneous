from random import randint

nouns = ['Night','Fire','Boy','Beat','Sun','Heart','Speed','Heartbeat']
locations = ['Space','Tokyo','The 90s']
verbs = ['Sleep','Dance','Rise','Beat','Remember','Run','Burn','Stand','Love']

titles = [
    'noun1 of noun2',
    'location noun',
    'No One verb in location',
    'verbing',
    'noun of the verbing noun',
    'noun',
    'verb Me',
    'verbing in location',
    'verbing Up For You',
    'Don\'t verb So Close',
    'nounAY nounA noun',
    'noun verber'
    ]

def getWord(category,rule=None):
    nouns = ['Night','Fire','Boy','Beat','Sun','Heart','Speed']
    locations = ['Space','Tokyo','The 90s']
    verbs = ['Sleep','Dance','Rise','Beat','Remember','Run','Burn','Stand','Love']
    w = ''
    if category == 'nouns':
        w = nouns[randint(0,len(nouns)-1)]
    elif category == 'locations':
        w = locations[randint(0,len(locations)-1)]
    elif category == 'verbs':
        w = verbs[randint(0,len(verbs)-1)]
        if rule == 'ing':
            if w[-1] is 'e':
                w = w[:-1]
            elif w in ['run']:
                w+='n'
            w+='ing'
        elif rule is 'er':
            if w in ['run']:
                w+='n'
            if w[-1] != 'e':
                w+='e'
            w+='r'
    return w

def addY(w):
    if w is 'fire':
        w = 'fier'
    elif w in 'sun':
        w+='n'
    w+='y'
    if w is 'boyy':
        w = 'boyish'
    return w


def printTitle():
    title = titles[randint(0,len(titles)-1)]
    types = [
        ['noun2','nouns',None],
        ['noun1','nouns',None],
        ['verber','verbs','er'],
        ['verbing','verbs','ing'],
        ['noun','nouns',None],
        ['verb','verbs',None],
        ['location','locations',None]
        ]
    if 'nounAY' in title:
        randWord = getWord('nouns')
        randWordY = addY(randWord)
        title = title.replace('nounAY',randWordY)
        title = title.replace('nounA',randWord)
    for type in types:
        if type[0] in title:
            title = title.replace(type[0],getWord(type[1],type[2]))
    return title

print printTitle()
