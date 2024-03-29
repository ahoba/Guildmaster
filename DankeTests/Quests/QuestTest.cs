﻿using Danke.Characters;
using Danke.Items;
using Danke.Quests;
using Danke.Quests.QuestStages;
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
                Title = new Danke.Text.RegionText()
                {
                    Text = "Test Quest 0"
                },
                Description = new Danke.Text.RegionText()
                {
                    Text = "Test Quest 0"
                },
                SuccessText = new Danke.Text.RegionText()
                {
                    Text = "The dungeons were successfully braved by your party, its spoils now belong to your guild!"
                },
                FailureText = new Danke.Text.RegionText()
                {
                    Text = "The treasures of the dungeon remain untouched, waiting for the next adventurers who dare try and loot it!"
                }
            };

            LinearQuestStage initialStage = new LinearQuestStage()
            {
                StageStartText = new Danke.Text.RegionText()
                {
                    Text = "Your party arrives at a dungeon! They see a lava river in their path..."
                },
                StageEndText = new Danke.Text.RegionText()
                {
                    Text = "Your party moves on after overcoming the lava river."
                }
            };

            QuestStage endStage = new TerminalQuestStage()
            {
                StageStartText = new Danke.Text.RegionText()
                {
                    Text = "You party arrived at the treasure room!"
                },
                StageEndText = new Danke.Text.RegionText()
                {
                    Text = "They carry all the gold and valuables they can before leaving the dungeon."
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

        class MockItem : Item
        {

        }

        [Test]
        public void LinearQuestWithProvision()
        {
            Item item = new MockItem()
            {
                Id = Guid.NewGuid(),
                Name = new Danke.Text.RegionText()
                {
                    Text = "Rope"
                }
            };

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

            IList<Item> provisions = new List<Item>()
            {
                item
            };

            Quest quest = new Quest()
            {
                Title = new Danke.Text.RegionText()
                {
                    Text = "Test Quest 0"
                },
                Description = new Danke.Text.RegionText()
                {
                    Text = "Test Quest 0"
                },
                SuccessText = new Danke.Text.RegionText()
                {
                    Text = "The dungeons were successfully braved by your party, its spoils now belong to your guild!"
                },
                FailureText = new Danke.Text.RegionText()
                {
                    Text = "The treasures of the dungeon remain untouched, waiting for the next adventurers who dare try and loot it!"
                }
            };

            LinearQuestStage initialStage = new LinearQuestStage()
            {
                StageStartText = new Danke.Text.RegionText()
                {
                    Text = "Your party arrives at a dungeon! They see a lava river in their path..."
                },
                StageEndText = new Danke.Text.RegionText()
                {
                    Text = "Your party moves on after overcoming the lava river."
                }
            };

            QuestStage endStage = new TerminalQuestStage()
            {
                StageStartText = new Danke.Text.RegionText()
                {
                    Text = "You party arrived at the treasure room!"
                },
                StageEndText = new Danke.Text.RegionText()
                {
                    Text = "They carry all the gold and valuables they can before leaving the dungeon."
                }
            };

            Roll roll = new Roll()
            {
                Consumables = new List<Consumable>()
                { 
                    new Consumable()
                    {
                        ItemId = item.Id,
                        Text = new Danke.Text.RegionText()
                        {
                            Text = "used a rope to jump over the lava river."
                        }
                    }
                },
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


        [Test]
        public void LinearQuestWithTwoProvision()
        {
            Item item0 = new MockItem()
            {
                Id = Guid.NewGuid(),
                Name = new Danke.Text.RegionText()
                {
                    Text = "Rope"
                }
            };

            Item item1 = new MockItem()
            {
                Id = item0.Id,
                Name = new Danke.Text.RegionText()
                {
                    Text = "Rope"
                }
            };

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

            IList<Item> provisions = new List<Item>()
            {
                item0,
                item1
            };

            Quest quest = new Quest()
            {
                Title = new Danke.Text.RegionText()
                {
                    Text = "Test Quest 0"
                },
                Description = new Danke.Text.RegionText()
                {
                    Text = "Test Quest 0"
                },
                SuccessText = new Danke.Text.RegionText()
                {
                    Text = "The dungeons were successfully braved by your party, its spoils now belong to your guild!"
                },
                FailureText = new Danke.Text.RegionText()
                {
                    Text = "The treasures of the dungeon remain untouched, waiting for the next adventurers who dare try and loot it!"
                }
            };

            LinearQuestStage initialStage = new LinearQuestStage()
            {
                StageStartText = new Danke.Text.RegionText()
                {
                    Text = "Your party arrives at a dungeon! They see a lava river in their path..."
                },
                StageEndText = new Danke.Text.RegionText()
                {
                    Text = "Your party moves on after overcoming the lava river."
                }
            };

            QuestStage endStage = new TerminalQuestStage()
            {
                StageStartText = new Danke.Text.RegionText()
                {
                    Text = "You party arrived at the treasure room!"
                },
                StageEndText = new Danke.Text.RegionText()
                {
                    Text = "They carry all the gold and valuables they can before leaving the dungeon."
                }
            };

            Roll roll = new Roll()
            {
                Consumables = new List<Consumable>()
                {
                    new Consumable()
                    {
                        ItemId = item0.Id,
                        Text = new Danke.Text.RegionText()
                        {
                            Text = "used a rope to jump over the lava river."
                        }
                    }
                },
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

        [Test]
        public void LinearQuestWithFailure()
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
                        TotalHp = 1,
                        TotalStamina = 1,
                        CurrentHp = 1,
                        CurrentStamina = 1
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
                        TotalHp = 1,
                        TotalStamina = 1,
                        CurrentHp = 1,
                        CurrentStamina = 1
                    }
            };

            Quest quest = new Quest()
            {
                Title = new Danke.Text.RegionText()
                {
                    Text = "Test Quest 0"
                },
                Description = new Danke.Text.RegionText()
                {
                    Text = "Test Quest 0"
                },
                SuccessText = new Danke.Text.RegionText()
                {
                    Text = "The dungeons were successfully braved by your party, its spoils now belong to your guild!"
                },
                FailureText = new Danke.Text.RegionText()
                {
                    Text = "The treasures of the dungeon remain untouched, waiting for the next adventurers who dare try and loot it!"
                }
            };

            LinearQuestStage initialStage = new LinearQuestStage()
            {
                StageStartText = new Danke.Text.RegionText()
                {
                    Text = "Your party arrives at a dungeon! They see a lava river in their path..."
                },
                StageEndText = new Danke.Text.RegionText()
                {
                    Text = "Your party moves on after overcoming the lava river."
                }
            };

            QuestStage endStage = new TerminalQuestStage()
            {
                StageStartText = new Danke.Text.RegionText()
                {
                    Text = "You party arrived at the treasure room!"
                },
                StageEndText = new Danke.Text.RegionText()
                {
                    Text = "They carry all the gold and valuables they can before leaving the dungeon."
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
                Threshold = 100,
                BaseHpDamage = 100,
                BaseStaminaDamage = 100
            };

            initialStage.NextStageRoll = roll;
            initialStage.NextStage = endStage;

            quest.InitialStage = initialStage;

            quest.QuestNotification += (object sender, QuestNotificationEventArgs eventArgs) =>
            {
                Console.WriteLine(eventArgs.Text);
            };

            bool q = quest.TryGo(characters, new Item[] { }, out string text);

            Assert.IsTrue(characters.Any(x => x.CurrentHp == 0));
            Assert.IsTrue(characters.Any(x => x.CurrentStamina == 0));
            Assert.IsFalse(q);
        }

        [Test]
        public void BinaryQuestWithSuccessBranch()
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

            Quest quest = new Quest()
            {
                Title = new Danke.Text.RegionText()
                {
                    Text = "Test Quest 0"
                },
                Description = new Danke.Text.RegionText()
                {
                    Text = "Test Quest 0"
                },
                SuccessText = new Danke.Text.RegionText()
                {
                    Text = "The dungeons were successfully braved by your party, its spoils now belong to your guild!"
                },
                FailureText = new Danke.Text.RegionText()
                {
                    Text = "The treasures of the dungeon remain untouched, waiting for the next adventurers who dare try and loot it!"
                }
            };

            BinaryQuestStage initialStage = new BinaryQuestStage()
            {
                StageStartText = new Danke.Text.RegionText()
                {
                    Text = "Your party arrives at a dungeon! They see a lava river in their path..."
                },
                FailureText = new Danke.Text.RegionText()
                {
                    Text = "While trying to jump, the floor crumbled beneath your party's feet...!"
                },
                SuccessText = new Danke.Text.RegionText()
                {
                    Text = "Your party moves on after overcoming the lava river."
                }
            };

            QuestStage successStage = new TerminalQuestStage()
            {
                StageStartText = new Danke.Text.RegionText()
                {
                    Text = "You party arrived at the treasure room!"
                },
                StageEndText = new Danke.Text.RegionText()
                {
                    Text = "They carry all the gold and valuables they can before leaving the dungeon."
                }
            };

            QuestStage failureStage = new TerminalQuestStage()
            {
                StageStartText = new Danke.Text.RegionText()
                {
                    Text = "Your party was taken to a tunnel!"
                },
                StageEndText = new Danke.Text.RegionText()
                {
                    Text = "Once upon leaving the tunnel, the party finds itself close to the city from where the adventure began."
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
                Threshold = 1,
                BaseHpDamage = 10,
                BaseStaminaDamage = 10
            };

            initialStage.NextStageRoll = roll;
            initialStage.SuccessStage = successStage;
            initialStage.FailureStage = failureStage;

            quest.InitialStage = initialStage;

            quest.QuestNotification += (object sender, QuestNotificationEventArgs eventArgs) =>
            {
                Console.WriteLine(eventArgs.Text);
            };

            bool q = quest.TryGo(characters, new Item[] { }, out string text);

            Assert.IsTrue(q);
        }

        [Test]
        public void BinaryQuestWithFailureBranch()
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

            Quest quest = new Quest()
            {
                Title = new Danke.Text.RegionText()
                {
                    Text = "Test Quest 0"
                },
                Description = new Danke.Text.RegionText()
                {
                    Text = "Test Quest 0"
                },
                SuccessText = new Danke.Text.RegionText()
                {
                    Text = "The dungeons were successfully braved by your party, its spoils now belong to your guild!"
                },
                FailureText = new Danke.Text.RegionText()
                {
                    Text = "The treasures of the dungeon remain untouched, waiting for the next adventurers who dare try and loot it!"
                }
            };

            BinaryQuestStage initialStage = new BinaryQuestStage()
            {
                StageStartText = new Danke.Text.RegionText()
                {
                    Text = "Your party arrives at a dungeon! They see a lava river in their path..."
                },
                FailureText = new Danke.Text.RegionText()
                {
                    Text = "While trying to jump, the floor crumbled beneath your party's feet...!"
                },
                SuccessText = new Danke.Text.RegionText()
                {
                    Text = "Your party moves on after overcoming the lava river."
                }
            };

            QuestStage successStage = new TerminalQuestStage()
            {
                StageStartText = new Danke.Text.RegionText()
                {
                    Text = "You party arrived at the treasure room!"
                },
                StageEndText = new Danke.Text.RegionText()
                {
                    Text = "They carry all the gold and valuables they can before leaving the dungeon."
                }
            };

            QuestStage failureStage = new TerminalQuestStage()
            {
                StageStartText = new Danke.Text.RegionText()
                {
                    Text = "Your party was taken to a tunnel!"
                },
                StageEndText = new Danke.Text.RegionText()
                {
                    Text = "Once upon leaving the tunnel, the party finds itself close to the city from where the adventure began."
                },
                IsQuestFailure = true
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
                Threshold = 1000,
                BaseHpDamage = 10,
                BaseStaminaDamage = 10
            };

            initialStage.NextStageRoll = roll;
            initialStage.SuccessStage = successStage;
            initialStage.FailureStage = failureStage;

            quest.InitialStage = initialStage;

            quest.QuestNotification += (object sender, QuestNotificationEventArgs eventArgs) =>
            {
                Console.WriteLine(eventArgs.Text);
            };

            bool q = quest.TryGo(characters, new Item[] { }, out string text);

            Assert.IsFalse(q);
        }
    }
}
