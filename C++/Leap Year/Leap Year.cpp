#include <iostream>
#include <string>

bool parsable(std::string s)
{
	for (int x = 0; x < s.size(); x++)
	{
		if ((s[x] < 48 || s[x] > 57) && (x != 0 || s[0] != 45))
		{
			return false;
		}
	}
	return true;
}

int parseString(std::string s)
{
	if (!s.empty() && parsable(s))
	{
		return std::stoi(s);
	}

	else return -1;
}


int main()
{
	std::cout << "Hello please enter the your year.\nKeep in mind this is only for the Gregorian Calendar which was adopted in 1582.\n";

	while (true)
	{
		try
		{
			std::string input = "";
			int year = 0;
			std::cin >> input;
			year = parseString(input);

			if (year > 1581)
			{
				if (year % 100 == 0)
				{
					if (year % 400 == 0)
					{
						std::cout << year << " is a leap year.";
					}

					else std::cout << year << " is a not leap year.";
				}

				else if (year % 4 == 0)
				{
					std::cout << year << " is a leap year.";
				}

				else std::cout << year << " is not a leap year.";

				break;
			}

			else
			{
				throw year;
			}
		}

		catch (int year)
		{
			if (year >= 0)
			{
				std::cout << year << " happened before 1582.\n";
			}

			else
			{
				std::cout << "Please enter a valid input.\n";
			}
		}
	}
}