using Danke.Characters;
using Danke.Items;
using Danke.Quests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DankeTests.Quests
{
    [TestFixture]
    public class QuestTest
    {
        [SetUp]
        public void Init()
        {

        }

        [Test]
        public void LinearQuest0()
        {
            IEnumerable<Character> characters = new Character[]
            {
                new Character()
                {
                    Name = "John Doe",
                    Stats = new int[]
                    {
                        5,
                        5,
                        5,
                        5,
                        5,
                        5
                    },
                    TotalHp = 100,
                    TotalStamina = 100,
                    CurrentHp = 100,
                    CurrentStamina = 100
                },
                new Character()
                {
                    Name = "Jane Doe",
                    Stats = new int[]
                    {
                        5,
                        5,
                        5,
                        5,
                        5,
                        5
                    },
                    TotalHp = 100,
                    TotalStamina = 100,
                    CurrentHp = 100,
                    CurrentStamina = 100
                }
            };

            IList<Item> provisions = new List<Item>();

            Quest quest = new Quest()
            {
                RegionTitle = new Danke.Text.RegionText()
                {
                    Text = "Test Quest 0"
                },
                RegionDescription = new Danke.Text.RegionText()
                {
                    Text = "Test Quest 0"
                },
            };

            LinearStage initialStage = new LinearStage()
            {
                Text = new Danke.Text.RegionText()
                {
                    Text = "Your party arrives at a dungeon! They see a lava river in their path..."
                }
            };

            QuestStage endStage = new EndStage()
            {
                Text = new Danke.Text.RegionText()
                {
                    Text = "You party arrived at the treasure room!"
                }
            };

            Roll roll = new Roll()
            {
                TextBeforeRoll = new Danke.Text.RegionText()
                {
                    Text = " attempts to jump over the lava river..."
                },
                TextOnSuccess = new Danke.Text.RegionText()
                {
                    Text = " successfully jumps over the lava river, sustaining minor damages!"
                },
                TextOnFailure = new Danke.Text.RegionText()
                {
                    Text = " suffers a significant amount of damage while jumping the lava river..."
                },
                TestedStat = Stats.Charisma,
                RollType = RollType.WholeParty,
                Threshold = 10,
                BaseHpDamage = 10,
                BaseStaminaDamage = 10
            };

            initialStage.NextStageRoll = roll;
            initialStage.NextStage = endStage;

            quest.InitialStage = initialStage;

            quest.QuestNotification += (object sender, QuestNotificationEventArgs eventArgs) =>
            {
                Console.WriteLine(eventArgs.Text);
            };

            bool q = quest.TryGo(characters, provisions, out string text);

            Assert.IsTrue(q);
        }
    }
}
