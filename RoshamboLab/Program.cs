using RoshamboLab;

string userContinue = "y";

Console.WriteLine("Welcome to the Roshambo game!\n");
HumanPlayer humanPlayer = new();

Console.WriteLine("What is your name: ");
humanPlayer.Name = Console.ReadLine();

do
{
    bool validThrow = false;
    bool validcontinue = false;
    Roshambo opponentThrow = new Roshambo();
    Roshambo playerThrow = new Roshambo();
    string outcome = "";

    Validator validator = new();
    Console.WriteLine("\nWhat kind of opponent do you want (rock player / random player): ");
    string playerType = Console.ReadLine();
    validator.GetOtherPlayer(playerType);

    if (playerType == "RockPlayer")
    {
        RockPlayer rockPlayer = new();
        opponentThrow = rockPlayer.GenerateRoshambo();
    }
    else if (playerType == "RandomPlayer")
    {
        RandomPlayer randomPlayer = new();
        opponentThrow = randomPlayer.GenerateRoshambo();
    }
    else
    {
        continue;
    }

    do
    {
        Console.WriteLine("\nWhat is your throw: ");
        string tryThrow = Console.ReadLine();


        if (validator.GetRoshambo(tryThrow))
        {
            humanPlayer.Value = tryThrow.ToLower();
            validThrow = true;
        }
        else
        {
            continue;
        }
    } while (validThrow is false);

    playerThrow = humanPlayer.GenerateRoshambo();

    switch (playerThrow)
    {
        case Roshambo.rock:
            switch (opponentThrow)
            {
                case Roshambo.rock:
                    if (playerType == "RockPlayer")
                    {
                        RockPlayer.Ties++;
                    }
                    else
                    {
                        RandomPlayer.Ties++;
                    }
                    HumanPlayer.Ties++;
                    outcome = "ties";
                    break;
                case Roshambo.paper:
                    if (playerType == "RockPlayer")
                    {
                        RockPlayer.Wins++;
                    }
                    else
                    {
                        RandomPlayer.Wins++;
                    }
                    HumanPlayer.Losses++;
                    outcome = "loses to";
                    break;
                case Roshambo.scissors:
                    if (playerType == "RockPlayer")
                    {
                        RockPlayer.Losses++;
                    }
                    else
                    {
                        RandomPlayer.Losses++;
                    }
                    HumanPlayer.Wins++;
                    outcome = "beats";
                    break;
                default:
                    break;
            }
            break;
        case Roshambo.paper:
            switch (opponentThrow)
            {
                case Roshambo.rock:
                    if (playerType == "RockPlayer")
                    {
                        RockPlayer.Losses++;
                    }
                    else
                    {
                        RandomPlayer.Losses++;
                    }
                    HumanPlayer.Wins++;
                    outcome = "beats";
                    break;
                case Roshambo.paper:
                    if (playerType == "RockPlayer")
                    {
                        RockPlayer.Ties++;
                    }
                    else
                    {
                        RandomPlayer.Ties++;
                    }
                    HumanPlayer.Ties++;
                    outcome = "ties";
                    break;
                case Roshambo.scissors:
                    if (playerType == "RockPlayer")
                    {
                        RockPlayer.Wins++;
                    }
                    else
                    {
                        RandomPlayer.Wins++;
                    }
                    HumanPlayer.Losses++;
                    outcome = "loses to";
                    break;
                default:
                    break;
            }
            break;
        case Roshambo.scissors:
            switch (opponentThrow)
            {
                case Roshambo.rock:
                    if (playerType == "RockPlayer")
                    {
                        RockPlayer.Wins++;
                    }
                    else
                    {
                        RandomPlayer.Wins++;
                    }
                    HumanPlayer.Losses++;
                    outcome = "loses to";
                    break;
                case Roshambo.paper:
                    if (playerType == "RockPlayer")
                    {
                        RockPlayer.Losses++;
                    }
                    else
                    {
                        RandomPlayer.Losses++;
                    }
                    HumanPlayer.Wins++;
                    outcome = "beats";
                    break;
                case Roshambo.scissors:
                    if (playerType == "RockPlayer")
                    {
                        RockPlayer.Ties++;
                    }
                    else
                    {
                        RandomPlayer.Ties++;
                    }
                    HumanPlayer.Ties++;
                    outcome = "ties";
                    break;
                default:
                    break;
            }
            break;
        default:
            break;
    }

    Console.WriteLine($"\n{humanPlayer.Name} throws {playerThrow} and {outcome} {playerType}, who threw {opponentThrow}!\n");
    Console.WriteLine("{0,-15} {1,-10} {2,-10} {3,0}", "Player", "Wins", "Losses", "Ties");
    Console.WriteLine("{0,-15} {1,-10} {2,-10} {3,0}", $"{humanPlayer.Name}", $"{HumanPlayer.Wins}", $"{HumanPlayer.Losses}", $"{HumanPlayer.Ties}");
    Console.WriteLine("{0,-15} {1,-10} {2,-10} {3,0}", $"RockPlayer", $"{RockPlayer.Wins}", $"{RockPlayer.Losses}", $"{RockPlayer.Ties}");
    Console.WriteLine("{0,-15} {1,-10} {2,-10} {3,0}", $"RandomPlayer", $"{RandomPlayer.Wins}", $"{RandomPlayer.Losses}", $"{RandomPlayer.Ties}");

    do
    {
        Console.WriteLine("\nDo you want to play again? ");
        userContinue = Console.ReadLine();
        if (validator.GetYN(userContinue))
        {
            break;
        }
        else
        {
            continue;
        }
    } while (validcontinue is false);

} while (userContinue.ToLower() == "y");

Console.WriteLine("\nThanks for playing!");



