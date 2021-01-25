using System;

namespace REdditUpvoteCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            r:
            double finalVote = 0;
            double upvotes = 0;
            double downvotes = 0;
            double totalVotes = 0;
            double upvotePercent = 0;
            double downvotePercent = 0;

            Console.Write("Post Score: ");
            finalVote = Convert.ToInt32(Console.ReadLine());

            Console.Write("Percent upvoted (eg. 0.67, 0.34, 0.90): ");
            upvotePercent = Convert.ToDouble(Console.ReadLine());

            //Step 1
            downvotePercent = Math.Round(1.00 - upvotePercent, 2, MidpointRounding.AwayFromZero);
            totalVotes = Math.Round(finalVote / (upvotePercent - downvotePercent), 0, MidpointRounding.AwayFromZero);

            //Step 2
            upvotes = Math.Round(totalVotes - (downvotePercent * totalVotes), 0, MidpointRounding.AwayFromZero);

            //step 3
            downvotes = Math.Round(totalVotes - upvotes, 0, MidpointRounding.AwayFromZero);

            //Result
            Console.WriteLine($"Your post's stats:\nTotal Score: {finalVote}, with {upvotes}(±1) upvotes and {downvotes}(±1) downvotes.");
            Console.WriteLine($"A total of {totalVotes}(±1) people voted, {upvotePercent*100}% of which upvoted, and {downvotePercent*100}% of which downvoted.");
            Console.WriteLine("\nWhy the uncertain numbers? Reddit does not provide the exact percentage of upvotes, it is rounded to the nearest whole number." +
                " That can throw off the calculator by 1 vote in either way.");
            Console.ReadLine();

            Console.WriteLine("\nRetry? (y/n)");
            string ans = Console.ReadLine();

            if (ans.ToLower().Trim() == "y")
            {
                goto r;
            }
        }
    }
}
