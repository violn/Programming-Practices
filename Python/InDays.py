def getOrdinal(number):
    if number > 10 and number < 20:
        return "th"

    ordCase = {1 : "st", 2 : "nd", 3 : "rd"}
    first_digit = int(str(number)[len(str(number)) - 1])
    if first_digit in ordCase:
        return ordCase[first_digit]
    else:
        return "th"

def isLeap(year):
    if year > 1581:
        if year % 100 == 0:
            if year % 400 == 0:
                return True
            else:
                return False
        elif year % 4 == 0:
                return True
        else:
            return False
    else:
        return False

class Month:
    name = ""
    maxDays = 0

    def __init__(self, name, maxDays):
        self.name = name
        self.maxDays = maxDays

class Calendar:
    months = (Month("January", 31),
              Month("February", 28), 
              Month("March", 31),
              Month("April", 30),
              Month("May", 31),
              Month("June", 30),
              Month("July", 31),
              Month("August", 31),
              Month("September", 30),
              Month("October", 31),
              Month("November", 30),
              Month("December", 31))

    def findPriorDays(self, monthNum, year):
        priorDays = 0
        iterateNum = 0
        while iterateNum < monthNum - 1:
            priorDays += self.months[iterateNum].maxDays + (1 if iterateNum == 1 and isLeap(year) else 0)
            iterateNum += 1
        return priorDays

print("Welcome! The jist of this program is to find how many days in a given date is to a that dates year")
print("Please enter your date. (mm/dd/yyyy)")

while True:
    try:
        date = input("")
        fdate = date.split("/")
        days = (Calendar().findPriorDays(int(fdate[0]), int(fdate[2]))) + int(fdate[1])
        message = "{} {}{} is {} days into the year {}."
        print(message.format(Calendar().months[int(fdate[0]) - 1].name, int(fdate[1]), getOrdinal(int(fdate[1])), days, int(fdate[2])))
        break

    except:
        print("Please enter a valid date.")