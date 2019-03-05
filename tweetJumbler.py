import tweepy
from secrets import API_KEY, API_SECRET_KEY, ACCESS_TOKEN, ACCESS_TOKEN_SECRET
from random import randint


#Tweepy setup
auth = tweepy.OAuthHandler(API_KEY, API_SECRET_KEY)
auth.set_access_token(ACCESS_TOKEN, ACCESS_TOKEN_SECRET)
api = tweepy.API(auth)


def setupTweets(username):
    wordDict = {'INIT':[]}
    tweets = api.user_timeline(username,count=201)
    for tweet in tweets:
        words = tweet.text.split(' ')
        wordDict['INIT'].append(words[0])
        for i in range(len(words)-1):
            if words[i] in wordDict:
                wordDict[words[i]].append(words[i+1])
            else:
                wordDict[words[i]] = [words[i+1]]
        if words[-1] in wordDict:
            wordDict[words[-1]].append('TERMINATE')
        else:
            wordDict[words[-1]] = ['TERMINATE']
    return wordDict


def generateTweet():
    tweet = ''
    word = wordDict['INIT'][randint(0,len(wordDict['INIT'])-1)]
    tweet+=word
    word = wordDict[word][randint(0,len(wordDict[word])-1)]
    while word != 'TERMINATE' and len(tweet) <280:
        tweet+=' '
        tweet+=word
        word = wordDict[word][randint(0,len(wordDict[word])-1)]
    for word in tweet.split(' '):
        if word == u'RT' or '@' in word or 'http' in word:
            tweet = tweet.replace(word,'')
        tweet = tweet.replace('  ',' ')
    if len(tweet) == 0:
        tweet = generateTweet()
    return tweet

wordDict = setupTweets('realdonaldtrump')
print generateTweet()
