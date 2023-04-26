namespace Exam
{
    class Program
    {
        static bool IsSame(int own1, int own2)
        {
            if (own1 == own2)
            {
                return true;
            }

            return false;
        }
        static bool IsValid(int slot, char[] lots)
        {
            if (slot <= 0)
            {
                return true;
            }

            return false;
        }
        static bool IsReserved(int slot, char[] lots)
        {
            if (slot - 1 >= 0 && lots[slot - 1] == 'X')
            {
                return true;
            }

            return false;
        }
        static bool HasEntrance(char[] lots)
        {
            int slotsLeft = 0;
            for (int i = 0; i < lots.Length; i++)
            {
                if (lots[i] == '_')
                {
                    slotsLeft = slotsLeft + 1;
                }
            }

            if (slotsLeft == 1)
            {
                return true;
            }
            return false;
        }
        static bool CheckSpaces(char[] lots)
        {
            for (int i = 0; i < lots.Length; i++)
            {
                if (lots[i] == '_')
                {
                    return true;
                }
            }

            return false;
        }
        static bool IsSpaced(int slot, int slot2, char[] lots)
        {
            if (slot - 1 < 0 || slot2 - 1 < 0)
            {
                return false;
            }

            lots[slot - 1] = 'X';
            lots[slot2 - 1] = 'X';
            if (CheckSpaces(lots))
            {
                lots[slot - 1] = '_';
                lots[slot2 - 1] = '_';
                return false;
            }

            lots[slot - 1] = '_';
            lots[slot2 - 1] = '_';
            return true;
        }
        static void ShowLots(char[] lots)
        {
            for (int i = 0; i < lots.Length; i++)
            {
                Console.Write(lots[i] + " ");
            }

            Console.WriteLine(" ");
        }
        static void ReserveSlot(int slot, char[] lots)
        {
            if (IsValid(slot, lots))
            {
                return;
            }

            lots[slot - 1] = 'X';
        }
        static bool ReserveMain(int own1, int own2, char[] lots)
        {
            // Valid checks
            bool check1 = IsValid(own1, lots);
            bool check2 = IsValid(own2, lots);

            if (check1 && check2)
            {
                return false;
            }

            if (IsReserved(own1, lots))
            {
                Console.WriteLine("The stall is reserved.");
                return true;
            }

            if (IsReserved(own2, lots))
            {
                Console.WriteLine("The stall is reserved.");
                return true;
            }

            if (IsSame(own1, own2))
            {
                ReserveSlot(own1, lots);
            }

            if (IsSpaced(own1, own2, lots))
            {
                Console.WriteLine("The entrance can't be reserved.");
                return true;
            }

            ReserveSlot(own1, lots);
            ReserveSlot(own2, lots);

            ShowLots(lots);

            return true;
        }
        static void Main(string[] args)
        {
            char[] lots = new char[int.Parse(Console.ReadLine())];

            for (int i = 0; i < lots.Length; i++)
            {
                lots[i] = '_';
            }

            bool ShouldContinue = true;

            while (ShouldContinue)
            {
                if (HasEntrance(lots))
                {
                    Console.WriteLine("All stall are reserved.");
                    return;
                }
                int own1 = int.Parse(Console.ReadLine());
                int own2 = int.Parse(Console.ReadLine());
                ShouldContinue = ReserveMain(own1, own2, lots);
            }
        }  
    }
}