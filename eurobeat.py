from random import randint

nouns = ['Night','Fire','Boy','Beat','Sun','Heart','Speed','Heartbeat','Love',
            'Gas','Power','Race','Game','Car','Fantasy','Eurobeat']
locations = ['Space','Tokyo','The 90s','Danger','Japan']
verbs = ['Sleep','Dance','Rise','Beat','Remember','Run','Burn','Stand','Love',
            'Kill']

titles = [
    'noun1 of noun2',
    'location noun',
    'No One verb in location',
    'verbing',
    'noun1 of the verbing noun2',
    'noun',
    'verb Me',
    'verbing in location',
    'verbing Up For You',
    'Don\'t verb So Close',
    'nounAY nounA noun',
    'noun verber',
    'noun noun noun',
    'verbing my noun',
    'Get me noun',
    'The noun1 is the noun2',
    'The noun1 of the noun2',
    'My noun1 is noun2',
    'noun is in location',
    'Need noun',
    'Crazy for noun',
    'verbing noun',
    'location Fever',
    'noun Flight to location',
    'I need your noun',
    'noun Rhapsody',
    'Made in location',
    'Disco noun',
    'Super noun',
    ]

def getWord(category,rule=None):
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
            elif w in ['Run']:
                w+=w[-1]
            w+='ing'
        elif rule is 'er':
            if w in ['Run']:
                w+=w[-1]
            if w[-1] != 'e':
                w+='e'
            w+='r'
    return w

def addY(w):
    if w == 'Fire':
        w = 'Fier'
    elif w in ['Sun','Gas','Car']:
        w+=w[-1]
    elif w in ['Race']:
        w = w[:-1]
    w+='y'
    if w == 'Boyy':
        w = 'Boyish'
    elif w == 'Powery':
        w = 'Powerful'
    elif w == 'Fantasyy':
        w = 'Fantastical'
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
