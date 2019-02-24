from random import shuffle, randint

class Countdown(object):
    vowels = {'A':13,'E':21,'I':13,'O':13,'U':5}
    consonants = {'B':2,'C':3,'D':6,'F':2,'G':3,'H':2,'J':1,'K':1,'L':5,'M':4,
                  'N':8,'P':4,'Q':1,'R':9,'S':9,'T':9,'V':1,'W':1,'X':1,'Y':1,'Z':1}
    bigNumbers = [25,50,75,100]
    smallNumbers = [1,1,2,2,3,3,4,4,5,5,6,6,7,7,8,8,9,9,10,10]

    def numbersGame(self, pick=5):
        shuffle(self.bigNumbers)
        shuffle(self.smallNumbers)
        numbers = []
        while pick not in range(5):
            pick = int(input('How many big?\n'))
        while pick > 0:
            numbers.append(self.bigNumbers.pop(0))
            pick-=1
        while len(numbers) < 6:
            numbers.append(self.smallNumbers.pop(0))
        target = randint(100,999)
        return numbers, target


game = Countdown()
print(game.numbersGame(2))
