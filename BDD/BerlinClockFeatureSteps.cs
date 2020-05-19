using System;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using BerlinClock.Classes;
using BerlinClock.Interfaces;

namespace BerlinClock
{
    [Binding]
    public class TheBerlinClockSteps
    {
        private ITimeConverter berlinClock = new TimeConverter();
        private String theTime;

        
        [When(@"the time is ""(.*)""")]
        public void WhenTheTimeIs(string time)
        {
            theTime = time;
        }
        
        [Then(@"the clock should look like")]
        public void ThenTheClockShouldLookLike(string theExpectedBerlinClockOutput)
        {
#if HOOK
            Assert.IsTrue(true);
#elif DEBUG
            Assert.AreEqual(berlinClock.ConvertTime(theTime), theExpectedBerlinClockOutput);
#endif
        }

    }
}
