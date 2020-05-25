import random

dict_vocab = {
    #Contains vocabulary up to Lesson 7 of Minna no Nihongo
    #Commented out words are words I personally feel confident with, others that I'm very confident with (watashi, sensei etc) are omitted entirely
    #verbs are in their present-tense affirmative form

    #lesson 1
    'gakusei'       :   'student',
    'kaishain'      :   'office worker',
    'shain'         :   'employee',
    'ginkouin'      :   'banker',
    'isha'          :   'doctor',
    'kenkyuusha'    :   'researcher',
    'daigaku'       :   'university',
    'byouin'        :   'hospital',
    #lesson 2
    #'hon'           :   'book',
    'jisho'         :   'dictionary',
    'zasshi'        :   'magazine',
    'shinbun'       :   'newspaper',
    #'nooto'         :   'notebook',
    'techou'        :   'planner',
    'meishi'        :   'business card',
    'kaado'         :   'credit card',
    'enpitsu'       :   'pencil',
    #'boorupen'      :   'pen',
    'kagi'          :   'key',
    'tokei'         :   'clock',
    'kasa'          :   'umbrella',
    'kaban'         :   'bag',
    #'terebi'        :   'television',
    #'rajio'         :   'radio',
    'kuruma'        :   'car',
    'tsukue'        :   'desk',
    'isu'           :   'chair',
    'miyage'        :   'souvenir',
    #lesson 3
    'kyoushitsu'    :   'classroom',
    'shokudou'      :   'canteen',
    'jimusho'       :   'office',
    'kaigishitsu'   :   'meeting room',
    'uketsuke'      :   'reception',
    'heya'          :   'room',
    #'toire'         :   'toilet',
    'kaidan'        :   'staircase',
    'jidouhanbaiki' :   'vending machine',
    #'denwa'         :   'telephone',
    'kuni'          :   'country',
    'kaisha'        :   'company',
    'uchi'          :   'house',
    'kutsu'         :   'shoes',
    'uriba'         :   'department',
    'chika'         :   'basement',
    'ikura'         :   'how much',
    #'hyaku'         :   'hundred',
    #'sen'           :   'thousand',
    #'man'           :   'ten thousand',
    #Lesson 4
    'okimasu'       :   'wake up',
    'nemasu'        :   'sleep',
    'hatarakimasu'  :   'work',
    'yasumimasu'    :   'rest',
    'benkyoushimasu':   'study',
    'owarimasu'     :   'finish',
    'ginkou'        :   'bank',
    'yuubinkyaku'   :   'post office',
    'toshokan'      :   'library',
    'bijutsukan'    :   'art gallery',
    'ima'           :   'now',
    'gozen'         :   'a.m',
    'gogo'          :   'p.m',
    'asa'           :   'morning',
    'hiru'          :   'noon',
    'ban'           :   'evening',
    'yoru'          :   'night',
    'ototoi'        :   'day before yesterday',
    'kinou'         :   'yesterday',
    'kyou'          :   'today',
    'ashita'        :   'tomorrow',
    'asatte'        :   'day after tomorrow',
    'kesa'          :   'this morning',
    'konban'        :   'tonight',
    'yasumi'        :   'day off',
    'hiruyasumi'    :   'lunchtime',
    'shiken'        :   'exam',
    'kaigi'         :   'meeting',
    'eiga'          :   'film',
    'maiasa'        :   'every morning',
    'maiban'        :   'every night',
    'mainichi'      :   'every day',
    'getsuyoubi'    :   'monday',
    'kayoubi'       :   'tuesday',
    'suiyoubi'      :   'wednesday',
    'mokuyoubi'     :   'thursday',
    'kinyoubi'      :   'friday',
    'doyoubi'       :   'saturday',
    'nichiyoubi'    :   'sunday',
    #Lesson 5
    'ikimasu'       :   'go',
    'kimasu'        :   'come',
    'kaerimasu'     :   'return',
    'gakkou'        :   'school',
    'eki'           :   'station',
    'hikouki'       :   'aeroplane',
    'fune'          :   'ship',
    'densha'        :   'train',
    'chikatetsu'    :   'subway',
    'jidensha'      :   'bicycle',
    'aruite'        :   'on foot',
    'hito'          :   'person',
    'tomodachi'     :   'friend',
    'kare'          :   'boyfriend',
    'kanojo'        :   'girlfriend',
    'kazoku'        :   'family',
    'hitoride'      :   'alone',
    'senshuu'       :   'last week',
    'konshuu'       :   'this week',
    'raishuu'       :   'next week',
    'sengetsu'      :   'last month',
    'kongetsu'      :   'this month',
    'raigetsu'      :   'next month',
    'kyonen'        :   'last year',
    'kotoshi'       :   'this year',
    'rainen'        :   'next year',
    'tanjoubi'      :   'birthday',
    #Lesson 6
    'tabemasu'      :   'eat',
    'nomimasu'      :   'drink',
    'suimasu'       :   'smoke',
    'mimasu'        :   'see',
    'kikimasu'      :   'hear',
    'yomimasu'      :   'read',
    'kakimasu'      :   'write',
    'kaimasu'       :   'buy',
    'torimasu'      :   'take photo',
    'shimasu'       :   'do',
    'aimasu'        :   'meet',
    'gohan'         :   'meal',
    'asagohan'      :   'breakfast',
    'hirugohan'     :   'lunch',
    'bangohan'      :   'dinner',
    'pan'           :   'bread',
    'tamago'        :   'egg',
    'niku'          :   'meat',
    'sakana'        :   'fish',
    'yasai'         :   'vegetable',
    'kudamori'      :   'fruit',
    'mizu'          :   'water',
    'ocha'          :   'tea',
    'gyuunyuu'      :   'milk',
    'osake'         :   'alcohol',
    'tabako'        :   'cigarette',
    'tegami'        :   'letter',
    'shashin'       :   'photograph',
    'mise'          :   'shop',
    'niwa'          :   'garden',
    'shukudai'      :   'homework',
    'ohanami'       :   'cherry blossom viewing',
    'issho'         :   'together',
    'itsumo'        :   'usually',
    'tokidoki'      :   'sometimes',
    #Lesson 7
    'kirimasu'      :   'cut',
    'okurimasu'     :   'send',
    'agemasu'       :   'give',
    'moraimasu'     :   'receive',
    'kashimasu'     :   'lend',
    'karimasu'      :   'borrow',
    'oshiemasu'     :   'teach',
    'naraimasu'     :   'learn',
    'kakemasu'      :   'call',
    'te'            :   'hand',
    'hashi'         :   'chopsticks',
    'hasami'        :   'scissors',
    'keetai'        :   'mobile phone',
    'meeru'         :   'email',
    'hocchikisu'    :   'stapler',
    'keshigomu'     :   'rubber',
    'kami'          :   'paper',
    'hana'          :   'flower',
    'shatsu'        :   'shirt',
    'purezento'     :   'gift',
    'nimotsu'       :   'parcel',
    'okane'         :   'money',
    'kippu'         :   'ticket',
    'mou'           :   'already',
    'mada'          :   'not yet',
    'haha'          :   'mother (yours)',
    'chichi'        :   'father (yours)',
    'ryoushin'      :   'parents',
    'soba'          :   'grandmother (yours)',
    'sofu'          :   'grandfather (yours)',
    'sofuba'        :   'grandparents',
    'imouto'        :   'younger sister',
    'otouto'        :   'younger brother',
    'ane'           :   'elder sister (yours)',
    'ani'           :   'elder brother (yours)',
    'kyoudai'       :   'siblings',
    'tsuma'         :   'wife (yours)',
    'otto'          :   'husband (yours)',
    'musume'        :   'daughter',
    'musuko'        :   'son',
    'kodomo'        :   'children (yours)',
    'obaasan'       :   'grandmother (other)',
    'ojiisan'       :   'grandfather (other)',
    'okaasan'       :   'mother (other)',
    'otousan'       :   'father (other)',
    'oneesan'       :   'elder sister (other)',
    'oniisan'       :   'elder brother (other)',
    'okusan'        :   'wife (other)',
    'goshujin'      :   'husband (other)',

    }
    
l1 = ['gakusei','kaishain','shain','ginkouin','isha','kenkyuusha','daigaku','byouin']
l2 = ['hon','jisho','zasshi','shinbun','nooto','techou','meishi','kaado','enpitsu','boorupen','kagi','tokei','kasa','kaban','terebi','rajio','kuruma','tsukue','isu','miyage']
l3 = ['kyoushitsu','shokudou','jimusho','kaigishitsu','uketsuke','heya','toire','kaidan','jidouhanbaiki','denwa','kuni','kaisha','uchi','kutsu','uriba','chika','ikura','hyaku','sen','man']
l4 = ['okimasu','nemasu','hatarakimasu','yasumimasu','benkyoushimasu','owarimasu','ginkou','yuubinkyaku','toshokan','bijutsukan','ima','gozen','gogo','asa','hiru','ban','yoru','ototoi','kinou','kyou','ashita','asatte','kesa','konban','yasumi','hiruyasumi','shiken','kaigi','eiga','maiasa','maiban','mainichi','getsuyoubi','kayoubi','suiyoubi','mokuyoubi','kinyoubi','doyoubi','nichiyoubi']
l5 = ['ikimasu','kimasu','kaerimasu','gakkou','eki','hikouki','fune','densha','chikatetsu','jidensha','aruite','hito','tomodachi','kare','kanojo','kazoku','hitoride','senshuu','konshuu','raishuu','sengetsu','kongetsu','raigetsu','kyonen','kotoshi','rainen','tanjoubi']
l6 = ['tabemasu','nomimasu','suimasu','mimasu','kikimasu','yomimasu','kakimasu','kaimasu','torimasu','shimasu','aimasu','gohan','asagohan','hirugohan','bangohan','pan','tamago','niku','sakana','yasai','kudamori','mizu','ocha','gyuunyuu','osake','tabako','tegami','shashin','mise','niwa','shukudai','ohanami','issho','itsumo','tokidoki']
l7 = ['kirimasu','okurimasu','agemasu','moraimasu','kashimasu','karimasu','oshiemasu','naraimasu','kakemasu','te','hashi','hasami','keetai','meeru','hocchikisu','keshigomu','kami','hana','shatsu','purezento','nimotsu','okane','kippu','mou','mada','haha','chichi','ryoushin','soba','sofu','sofuba','imouto','otouto','ane','ani','kyoudai','tsuma','otto','musume','musuko','kodomo','obaasan','ojiisan','okaasan','otousan','oneesan','oniisan','okusan','goshujin']

lessons = [l1,l2,l3,l4,l5,l6,l7]

#enter study([1,2,3]) to only study lessons 1, 2, and 3, for example. Leave arguments blank to study all words
def study(arr=[]):
    study = True
    vocab = []
    jp = ''
    word = ''
    last=''
    if arr:
        i = 0
        while i < 7:
            if i+1 in arr:
                vocab.extend(lessons[i])
            i+=1
    else:
        for lesson in lessons:
            vocab.extend(lesson)

    while study:
        kv = random.randint(0,1)
        while word not in vocab or word == last:
            jp, en = random.choice(list(dict_vocab.items()))
            word = jp
            ans = en
        if kv:
            word = en
            ans = jp
        else:
            if '(' in ans:
                ans = ans[:ans.index('(')-1]

        guess = None
        print(word)
        while guess != ans and guess != "skip":
            guess = input()
            if guess == "owarimashita":
                study = False
                break
        if study and guess != 'skip':
            print('Correct')
            last = jp;
        if guess == "skip":
            print(ans)

#study()
