using System;

namespace PageObjectPatternPoll.Helpers
{
    public class TestSettings
    {
        public static string PollFormUrl { get; set; } = "https://testblogselenium.wordpress.com/pollform/";
        public static TimeSpan TimeSpan=new TimeSpan(0,0,15);
    }
}
