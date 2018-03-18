using System.Collections.Generic;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObjectPatternPoll.Pages
{
    public class PollPage
    {
        [FindsBy(How = How.CssSelector,Using= ".pds-question-top")]
        public IWebElement PollTitle { get; set; }

        [FindsBy(How = How.CssSelector,Using= ".entry-title")]
        public IWebElement Title { get; set; }

        [FindsBy(How = How.CssSelector,Using= ".pds-vote-button")]
        public IWebElement VoteButton { get; set; }

        [FindsBy(How = How.CssSelector,Using= ".pds-box-top .pds-feedback-group")]
        public IWebElement FeedbackResults { get; set; }

        [FindsBy(How = How.CssSelector,Using= ".pds-total-votes")]
        public IWebElement VotesCounter { get; set; }

        [FindsBy(How = How.CssSelector,Using= ".pds-return-poll")]
        public IWebElement ReturnToPoll { get; set; }

        [FindsBy(How = How.CssSelector,Using= ".pds-view-results")]
        public IWebElement ViewResults { get; set; }

        [FindsBy(How = How.CssSelector,Using= "#PDI_container9951516 .pds-answer-span")]
        public IList<IWebElement> PollAnswears { get; set; }

        [FindsBy(How = How.CssSelector,Using = ".pds-box")]
        public IWebElement PollBox { get; set; }

        public int AmountOfVotes => int.Parse(VotesCounter.FindElement(By.TagName("span")).Text);

        private IWebDriver driver;

        public PollPage(IObjectContainer container)
        {
            driver = container.Resolve<IWebDriver>();
            PageFactory.InitElements(driver,this);
        }
    }
}
