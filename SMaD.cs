using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using BepInEx;
using RogueLibsCore;
using HarmonyLib;
using UnityEngine;
using UnityEngine.Networking;
using System.Runtime.CompilerServices;

namespace SMaD
{
	[BepInPlugin(pluginGuid, pluginName, pluginVersion)]
	[BepInDependency(RogueLibs.pluginGuid, "2.0.0")]
	public class SMAD : BaseUnityPlugin
	{
        #region Info
        public const string pluginGuid = "ztbbz.streetsofrogue.smad";
		public const string pluginName = "SMaD";
		public const string pluginVersion = "0.4";
        #endregion

        public void Awake()
		{
			base.Logger.LogInfo("SMaD v0.4 here!");

            #region Patcher

            RoguePatcher patcher = new RoguePatcher(this, GetType());

			patcher.Postfix(typeof(RandomItems), "fillItems");

			patcher.Postfix(typeof(StatusEffects), "hasStatusEffect", new Type[1] { typeof(string) });

			patcher.Postfix(typeof(StatusEffects), "AddStatusEffect", new Type[6] { typeof(string), typeof(bool), typeof(Agent), typeof(NetworkInstanceId), typeof(bool), typeof(int) });

			patcher.Postfix(typeof(StatusEffects), "RemoveStatusEffect", new Type[4] { typeof(string), typeof(bool), typeof(NetworkInstanceId), typeof(bool) });

			patcher.Postfix(typeof(StatusEffects), "AddTrait", new Type[3] { typeof(string), typeof(bool), typeof(bool) });

			patcher.Postfix(typeof(StatusEffects), "RemoveTrait", new Type[2] { typeof(string), typeof(bool) });

			#endregion

			#region Custom StatusEffects
			#region Alien ration was eaten
			RogueLibs.CreateCustomName("Alien ration was eaten", "StatusEffect", new CustomNameInfo("Alien ration was eaten", null, null, null, null, "Сьеден паёк пришельцев" , null, null));
			RogueLibs.CreateCustomName("Alien ration was eaten", "Description", new CustomNameInfo("You ate the alien ration", null, null, null, null, "Вы съели паёк пришельцев", null,null ));
			#endregion

			#region Under KC Drink
			RogueLibs.CreateCustomName("Under KC drink", "StatusEffect", new CustomNameInfo("Under KC drink", null, null, null, null, "Под действием KC газировки", null, null));
			RogueLibs.CreateCustomName("Under KC drink", "Description", new CustomNameInfo("You drank KC drink", null, null, null, null, "Вы выпили KC газировку", null, null));
			#endregion

			#region Seasickness
			RogueLibs.CreateCustomName("Seasickness", "StatusEffect", new CustomNameInfo("Seasickness", null, null, null, null, "Морская болезнь", null, null));
			RogueLibs.CreateCustomName("Seasickness", "Description", new CustomNameInfo("*puking* Don't eat this anymore!", null, null, null, null, "*проблевавшись* Больше не ешьте это!", null, null));
			#endregion

			#region Temporary excess weight
			RogueLibs.CreateCustomName("Temporary excess weight", "StatusEffect", new CustomNameInfo("Temporary excess weight", null, null, null, null, "Временно жирный", null, null));
			RogueLibs.CreateCustomName("Temporary excess weight", "Description", new CustomNameInfo("I think you will have time to lose weight by the summer", null, null, null, null, "Думаю к лету успеете похудеть", null, null));
			#endregion

			#region Incest
			RogueLibs.CreateCustomName("Incest", "StatusEffect", new CustomNameInfo("Incest", null, null, null, null, "Кровосмешение", null, null));
			RogueLibs.CreateCustomName("Incest", "Description", new CustomNameInfo("Oh damn, let me lie down.. I don't feel good!", null, null, null, null, "Ох чёрт, дайте полежать.. мне что-то не хорошо", null, null));
			#endregion

			#region Steel Apple shell
			RogueLibs.CreateCustomName("Steel Apple shell", "StatusEffect", new CustomNameInfo("Steel Apple shell", null, null, null, null, "Оболочка от Стального Яблока", null, null));
			RogueLibs.CreateCustomName("Steel Apple shell", "Description", new CustomNameInfo("Now inside you and your organs are protected from bullets, enjoy the weight of it!", null, null, null, null, "Теперь внутри вы и ваши органы защищены от пуль, наслаждайтесь это тяжестью!", null, null));
			#endregion

			#region Cell regeneration
			RogueLibs.CreateCustomName("Cell regeneration", "StatusEffect", new CustomNameInfo("Cell regeneration", null, null, null, null, "Регенерация клеток", null, null));
			RogueLibs.CreateCustomName("Cell regeneration", "Description", new CustomNameInfo("Your cells are regenerating.. wait..", null, null, null, null, "Ваши клетки регенерируются.. подождите..", null, null));
			#endregion

			#region Red blood cell replenishment
			RogueLibs.CreateCustomName("Red blood cell replenishment", "StatusEffect", new CustomNameInfo("Red blood cell replenishment", null, null, null, null, "Восполнение эритроцитов", null, null));
			RogueLibs.CreateCustomName("Red blood cell replenishment", "Description", new CustomNameInfo("Yes, you will have red blood cells right now that you can wipe your ass with them!", null, null, null, null, "Да у вас щас будет эритроцитов что вы сможете ими свою жопу вытирать!", null, null));
			#endregion

			#region The power of Fish Oil!
			RogueLibs.CreateCustomName("The power of Fish Oil", "StatusEffect", new CustomNameInfo("The power of Fish Oil!", null, null, null, null, "Сила рыбьего жира!", null, null));
			RogueLibs.CreateCustomName("The power of Fish Oil", "Description", new CustomNameInfo("I hope you enjoyed the fish oil!", null, null, null, null, "Надеюсь вам понравился рыбий жир!", null, null));
			#endregion

			#region Sticky enrage
			RogueLibs.CreateCustomName("Sticky enrage", "StatusEffect", new CustomNameInfo("Sticky enrage", null, null, null, null, "Липкая ярость", null, null));
			RogueLibs.CreateCustomName("Sticky enrage", "Description", new CustomNameInfo("AAAAAAARGH! I'M READY TO TEAR EVERYONE APART!!", null, null, null, null, "ААААААААРХ! Я ГОТОВ РАСТЕРЗАТЬ КАЖДОГО!!", null, null));
			#endregion

			#region Nostalgia
			RogueLibs.CreateCustomName("Nostalgia", "StatusEffect", new CustomNameInfo("Nostalgia", null, null, null, null, "Ностальгия", null, null));
			RogueLibs.CreateCustomName("Nostalgia", "Description", new CustomNameInfo("Eh...nostalgia-nostalgia", null, null, null, null, "Эх...ностальгия-ностальгия", null, null));
			#endregion

			#region The Tears of Heaven are drunk
			RogueLibs.CreateCustomName("The Tears of Heaven are drunk", "StatusEffect", new CustomNameInfo("The Tears of Heaven are drunk", null, null, null, null, "Выпиты Cлёзы Небес", null, null));
			RogueLibs.CreateCustomName("The Tears of Heaven are drunk", "Description", new CustomNameInfo("Now you have the tears of the gods inside you.. unpleasant perhaps..", null, null, null, null, "Теперь внутри вас слезы богов..неприятно наверно..", null, null));
			#endregion

			#region Controlled by Brain Jellyfish
			RogueLibs.CreateCustomName("Controlled by Brain Jellyfish", "StatusEffect", new CustomNameInfo("Controlled by Brain Jellyfish", null, null, null, null, "Контролируется Мозговой Медузой", null, null));
			RogueLibs.CreateCustomName("Controlled by Brain Jellyfish", "Description", new CustomNameInfo("TO STING TO STING TO STING!", null, null, null, null, "УЖАЛИТЬ УЖАЛИТЬ УЖАЛИТЬ!", null, null));
			#endregion

			#region Drunk
			RogueLibs.CreateCustomName("Drunk1", "StatusEffect", new CustomNameInfo("Drunk", null, null, null, null, "Пьян", null, null));
			RogueLibs.CreateCustomName("Drunk1", "Description", new CustomNameInfo("Oh, I should have done little less.. *ik* drink", null, null, null, null, "Ох надо было поменьше чуто.. *ик* пить", null, null));
			#endregion

			#region Second heart
			RogueLibs.CreateCustomName("Second heart", "StatusEffect", new CustomNameInfo("Second heart", null, null, null, null, "Второе сердце", null, null));
			RogueLibs.CreateCustomName("Second heart", "Description", new CustomNameInfo("Now you have a second heart beating inside you .. are you .. happy?", null, null, null, null, "Теперь внутри вас бьется второе сердце.. вы.. рады?", null, null));
			#endregion

			#region Nuclear Barrel was drunk
			RogueLibs.CreateCustomName("Nuclear Barrel was drunk", "StatusEffect", new CustomNameInfo("Nuclear Barrel was drunk", null, null, null, null, "Выпита бочка с ядерными отходами", null, null));
			RogueLibs.CreateCustomName("Nuclear Barrel was drunk", "Description", new CustomNameInfo("You drank a Nuclear Barrel, you're crazy!", null, null, null, null, "Вы выпили бочку с ядерными отходами, да вы сумасшедший!", null, null));
			#endregion

			#region Nuclear spaghetti was eaten
			RogueLibs.CreateCustomName("Nuclear spaghetti was eaten", "StatusEffect", new CustomNameInfo("Nuclear spaghetti was eaten", null, null, null, null, "Сьедены ядерные спаггети", null, null));
			RogueLibs.CreateCustomName("Nuclear spaghetti was eaten", "Description", new CustomNameInfo("You don't have to be smart to eat nuclear spaghetti", null, null, null, null, "Чтобы съесть ядерные спагетти, большого ума не надо", null, null));
			#endregion

			#endregion

			#region Items

			#region KC Drink

			Sprite sprite_1 = RogueUtilities.ConvertToSprite(Properties.Resources.kc_fuzzi);
			CustomItem KCDrink = RogueLibs.CreateCustomItem("KCDrink", sprite_1, true,
				new CustomNameInfo("KC drink",
					null, null, null, null,
					"Газировка KC", null, null),
					new CustomNameInfo("A unique soda of its kind. KC is King of Caramel, according to rumors, when you drink it, you feel like your body is filled with caramel. Although scientists are not sure that this is caramel, but whatever it is, it move speed.",
						null, null, null, null,
						"Уникальная в своём роде газировка. KC это King of Сaramel или же Король Карамели, со слухов когда выпиваешь её, то чувствуешь как твоё тело наливается карамелью. Хотя учёные не уверены что это карамель, но чтобы это не было оно ускоряет движения.",
						null, null),
					item =>
					{
						item.itemType = "Food";
						item.Categories.Add("Alcohol");
						item.Categories.Add("SMaD");
						item.itemValue = 21;
						item.healthChange = 3;
						item.cantBeCloned = true;
						item.goesInToolbar = true;
						item.initCount = 1;
						item.rewardCount = 3;
						item.stackable = true;
					});

			KCDrink.UnlockCost = 5;
			KCDrink.CostInCharacterCreation = 5;
			KCDrink.CostInLoadout = 5;

			KCDrink.UseItem = (item, agent) =>
			{
				if (agent.statusEffects.hasTrait("OilRestoresHealth"))
					agent.SayDialogue("OnlyOilGivesHealth");
				else if (agent.statusEffects.hasTrait("BloodRestoresHealth"))
					agent.SayDialogue("OnlyBloodGivesHealth");
				else if (agent.electronic)
					agent.SayDialogue("OnlyChargeGivesHealth");
				else if (agent.statusEffects.hasTrait("CannibalizeRestoresHealth"))
					agent.SayDialogue("OnlyCannibalizeGivesHealth");
				else if (agent.health == agent.healthMax)
					agent.SayDialogue("HealthFullCantUseItem");
				else
				{

					{
						int heal = new ItemFunctions().DetermineHealthChange(item, agent);
						agent.statusEffects.ChangeHealth(heal);
						agent.statusEffects.AddStatusEffect("Fast" , false , false , 15);
						agent.statusEffects.AddStatusEffect("Under KC drink" , 15);
						item.database.SubtractFromItemCount(item, 1);
						if (agent.statusEffects.hasTrait("HealthItemsGiveFollowersExtraHealth") || agent.statusEffects.hasTrait("HealthItemsGiveFollowersExtraHealth2"))
							new ItemFunctions().GiveFollowersHealth(agent, heal);
						item.gc.audioHandler.Play(agent, "Drink");
						new ItemFunctions().UseItemAnim(item, agent);

					}
					return;

				}
				item.gc.audioHandler.Play(agent, "CantDo");
			};

			#endregion

			#region Conditioner IceCream

			Sprite sprite_2 = RogueUtilities.ConvertToSprite(Properties.Resources.vent_icecream);
			CustomItem CIceCream1 = RogueLibs.CreateCustomItem("CIceCream", sprite_2, true,
				new CustomNameInfo("Conditioner icecream",
					null, null, null, null,
					"Самоохлаждающееся мороженое", null, null),
					new CustomNameInfo("Is someone tired of their ice cream constantly melting? Well, now it will freeze together with the ice cream, because the ice cream has a built-in air conditioner! Yes, you heard right!",
						null, null, null, null,
						"Кому-то надоело что его мороженное постоянно тает? Ну теперь он замёрзнет вместе с мороженным, ведь в мороженное встроен кондиционер! Да-да вы не ослышались! ",
						null, null),
					item =>
					{
						item.itemType = "Food";
						item.Categories.Add("Food");
						item.Categories.Add("SMaD");
						item.itemValue = 25;
						item.healthChange = 20;
						item.cantBeCloned = true;
						item.goesInToolbar = true;
						item.initCount = 1;
						item.rewardCount = 1;
						item.stackable = true;
					});

			CIceCream1.UnlockCost = 5;
			CIceCream1.CostInCharacterCreation = 5;
			CIceCream1.CostInLoadout = 5;

			CIceCream1.UseItem = (item, agent) =>
			{
				if (agent.statusEffects.hasTrait("OilRestoresHealth"))
					agent.SayDialogue("OnlyOilGivesHealth");
				else if (agent.statusEffects.hasTrait("BloodRestoresHealth"))
					agent.SayDialogue("OnlyBloodGivesHealth");
				else if (agent.electronic)
					agent.SayDialogue("OnlyChargeGivesHealth");
				else if (agent.statusEffects.hasTrait("CannibalizeRestoresHealth"))
					agent.SayDialogue("OnlyCannibalizeGivesHealth");
				else if (agent.health == agent.healthMax)
					agent.SayDialogue("HealthFullCantUseItem");
				else
				{

					{
						int heal = new ItemFunctions().DetermineHealthChange(item, agent);
						agent.statusEffects.ChangeHealth(heal);
						agent.statusEffects.AddStatusEffect("Frozen");
						item.database.SubtractFromItemCount(item, 1);
						if (agent.statusEffects.hasTrait("HealthItemsGiveFollowersExtraHealth") || agent.statusEffects.hasTrait("HealthItemsGiveFollowersExtraHealth2"))
							new ItemFunctions().GiveFollowersHealth(agent, heal);
						item.gc.audioHandler.Play(agent, "UseFood");
						new ItemFunctions().UseItemAnim(item, agent);

					}
					return;

				}
				item.gc.audioHandler.Play(agent, "CantDo");
			};

			#endregion

			#region Botex Leg

			Sprite sprite_5 = RogueUtilities.ConvertToSprite(Properties.Resources.botex_leg);
			CustomItem BotexLeg1 = RogueLibs.CreateCustomItem("BotexLeg", sprite_5, true,
				new CustomNameInfo("Botex leg",
					null, null, null, null,
					"Ботексная ножка", null, null),
					new CustomNameInfo("Chicken leg straight from one of the most famous fast food restaurants with a secret ingredient. Oversaturating the body causes instant gigantism and excess weight.",
						null, null, null, null,
						"Куриная ножка прямиком из одного из самых известных ресторанов быстрого питания с секретным ингредиентом. Перенасыщая организм вызывает мгновенный гигантизм и лишний вес.",
						null, null),
					item =>
					{
						item.itemType = "Food";
						item.Categories.Add("Food");
						item.Categories.Add("SMaD");
						item.itemValue = 54;
						item.healthChange = 15;
						item.cantBeCloned = true;
						item.goesInToolbar = true;
						item.initCount = 1;
						item.rewardCount = 1;
						item.stackable = true;
					});

			BotexLeg1.UnlockCost = 6;
			BotexLeg1.CostInCharacterCreation = 6;
			BotexLeg1.CostInLoadout = 6;

			BotexLeg1.UseItem = (item, agent) =>
			{
				if (agent.statusEffects.hasTrait("OilRestoresHealth"))
					agent.SayDialogue("OnlyOilGivesHealth");
				else if (agent.statusEffects.hasTrait("BloodRestoresHealth"))
					agent.SayDialogue("OnlyBloodGivesHealth");
				else if (agent.electronic)
					agent.SayDialogue("OnlyChargeGivesHealth");
				else if (agent.statusEffects.hasTrait("CannibalizeRestoresHealth"))
					agent.SayDialogue("OnlyCannibalizeGivesHealth");
				else if (agent.health == agent.healthMax)
					agent.SayDialogue("HealthFullCantUseItem");
				else
				{

					{
						int heal = new ItemFunctions().DetermineHealthChange(item, agent);
						agent.statusEffects.ChangeHealth(heal);
						//agent.statusEffects.AddStatusEffect("Slow" , false, false , 20);
						agent.statusEffects.AddStatusEffect("Temporary excess weight" , 20); 
						//agent.statusEffects.AddStatusEffect("Giant" , false , false , 20);
						item.database.SubtractFromItemCount(item, 1);
						if (agent.statusEffects.hasTrait("HealthItemsGiveFollowersExtraHealth") || agent.statusEffects.hasTrait("HealthItemsGiveFollowersExtraHealth2"))
							new ItemFunctions().GiveFollowersHealth(agent, heal);
						item.gc.audioHandler.Play(agent, "UseFood");
						new ItemFunctions().UseItemAnim(item, agent);

					}
					return;

				}
				item.gc.audioHandler.Play(agent, "CantDo");
			};

			#endregion

			#region BOOMCorn

			Sprite sprite_6 = RogueUtilities.ConvertToSprite(Properties.Resources.boomkorn);
			CustomItem BOOMCorn = RogueLibs.CreateCustomItem("BOOMCorn", sprite_6, true,
				new CustomNameInfo("BOOMCorn",
					null, null, null, null,
					"BOOMкорн", null, null),
					new CustomNameInfo("This item was still in the Hitman beta, but for their game it is too refined a way to kill. If you wanted to become a kamikaze, here's your chance.  As you can understand, this is not popcorn, but just a bomb in a XXL popcorn bag.",
						null, null, null, null,
						"Этот BOOMкорн был ещё в бете Hitman`а, но для их игры это слишком изысканный способ убийства. Если вы хотели стать камикадзе, то вот ваш шанс.  Как можно понять это не попкорн, а всего лишь бомба в XXL пакете от попкорна.",
						null, null),
					item =>
					{
						item.itemType = "Food";
						item.Categories.Add("Food");
						item.Categories.Add("SMaD");
						item.itemValue = 37;
						item.healthChange = 0;
						item.cantBeCloned = true;
						item.goesInToolbar = true;
						item.initCount = 1;
						item.rewardCount = 1;
						item.stackable = true;
					});

			BOOMCorn.UnlockCost = 5;
			BOOMCorn.CostInCharacterCreation = 5;
			BOOMCorn.CostInLoadout = 5;

			BOOMCorn.UseItem = (item, agent) =>
			{
				if (agent.statusEffects.hasTrait("OilRestoresHealth"))
					agent.SayDialogue("OnlyOilGivesHealth");
				else if (agent.statusEffects.hasTrait("BloodRestoresHealth"))
					agent.SayDialogue("OnlyBloodGivesHealth");
				else if (agent.electronic)
					agent.SayDialogue("OnlyChargeGivesHealth");
				else if (agent.statusEffects.hasTrait("CannibalizeRestoresHealth"))
					agent.SayDialogue("OnlyCannibalizeGivesHealth");
				else if (agent.health == agent.healthMax)
					agent.SayDialogue("HealthFullCantUseItem");
				else
				{

					{
						int heal = new ItemFunctions().DetermineHealthChange(item, agent);
						agent.statusEffects.ChangeHealth(heal);
						item.database.SubtractFromItemCount(item, 1);
						if (agent.statusEffects.hasTrait("HealthItemsGiveFollowersExtraHealth") || agent.statusEffects.hasTrait("HealthItemsGiveFollowersExtraHealth2"))
							new ItemFunctions().GiveFollowersHealth(agent, heal);
						item.gc.audioHandler.Play(agent, "UseFood");
						new ItemFunctions().UseItemAnim(item, agent);
						agent.gc.spawnerMain.SpawnExplosion(agent, agent.tr.position, "Normal", false, -1, false, true).agent = agent;
					}
					return;
				}
				item.gc.audioHandler.Play(agent, "CantDo");
			};

			#endregion

			#region Fish from Well

			Sprite sprite_7 = RogueUtilities.ConvertToSprite(Properties.Resources.fish_of_luck);
			CustomItem FishOfLuck = RogueLibs.CreateCustomItem("FishOfLuck", sprite_7, true,
				new CustomNameInfo("Fish from Well",
					null, null, null, null,
					"Рыба из Колодца", null, null),
					new CustomNameInfo("The legendary fish that was caught from the very Well. it's all dry, but so warm.. Is it edible? Is unknown.. no one has tried it, but you can be the first! But according to the legends, it gives a surge of strength, heals all wounds and gives a sense of good luck.",
						null, null, null, null,
						"Легендарная рыба которую выловили из того самого Колодца.. она вся сухая, но такая тёплая.. Возможно она съедобная? Неизвестно.. никто не пробовал, но вы можете стать первым! Но судя по легендам она даёт прилив сил, залечивает все раны и даёт ощущение удачи. ",
						null, null),
					item =>
					{
						item.itemType = "Food";
						item.Categories.Add("Food");
						item.Categories.Add("SMaD");
						item.Categories.Add("Legend");
						item.itemValue = 37;
						item.healthChange = 500;
						item.cantBeCloned = true;
						item.goesInToolbar = true;
						item.initCount = 1;
						item.rewardCount = 1;
						item.stackable = true;
					});

			FishOfLuck.UnlockCost = 20;
			FishOfLuck.CostInCharacterCreation = 20;
			FishOfLuck.CostInLoadout = 20;

			FishOfLuck.UseItem = (item, agent) =>
			{
				if (agent.statusEffects.hasTrait("OilRestoresHealth"))
					agent.SayDialogue("OnlyOilGivesHealth");
				else if (agent.statusEffects.hasTrait("BloodRestoresHealth"))
					agent.SayDialogue("OnlyBloodGivesHealth");
				else if (agent.electronic)
					agent.SayDialogue("OnlyChargeGivesHealth");
				else if (agent.statusEffects.hasTrait("CannibalizeRestoresHealth"))
					agent.SayDialogue("OnlyCannibalizeGivesHealth");
				else if (agent.health == agent.healthMax)
					agent.SayDialogue("HealthFullCantUseItem");
				else
				{

					{
						int heal = new ItemFunctions().DetermineHealthChange(item, agent);
						agent.statusEffects.ChangeHealth(heal);
						agent.statusEffects.AddStatusEffect("NiceSmelling");
						agent.statusEffects.AddStatusEffect("Fast");
						item.database.SubtractFromItemCount(item, 1);
						if (agent.statusEffects.hasTrait("HealthItemsGiveFollowersExtraHealth") || agent.statusEffects.hasTrait("HealthItemsGiveFollowersExtraHealth2"))
							new ItemFunctions().GiveFollowersHealth(agent, heal);
						item.gc.audioHandler.Play(agent, "UseFood");
						new ItemFunctions().UseItemAnim(item, agent);
					}
					return;
				}
				item.gc.audioHandler.Play(agent, "CantDo");
			};

			#endregion

			#region Juicy Watermelon

			Sprite sprite_8 = RogueUtilities.ConvertToSprite(Properties.Resources.blood_arbyz);
			CustomItem JuicyWatermelon = RogueLibs.CreateCustomItem("JuicyWatermelon", sprite_8, true,
				new CustomNameInfo("Juicy watermelon",
					null, null, null, null,
					"Сочный Арбуз", null, null),
					new CustomNameInfo("Mmmmmmm.. how juicy and delicious this watermelon is..watermelon juice is flowing out of it.. or is it not juice? I won't torment you. It restores 80 HP to Vampires when people are only 30.. keep in mind that vampires are good, people are bad, I'm talking about incest.",
						null, null, null, null,
						"Ммммммм.. какой сочный и вкусный этот арбуз..из него так и течёт арбузный сок.. или это не сок? Не буду томить. Он восстанавливает Вампирам 80 ХП, когда людям только 30.. учтите что вампирам хорошо, людям плохо, я про кровосмешение.",
						null, null),
					item =>
					{
						item.itemType = "Food";
						item.Categories.Add("Food");
						item.Categories.Add("SMaD");
						item.itemValue = 37;
						item.healthChange = 0;
						item.cantBeCloned = true;
						item.goesInToolbar = true;
						item.initCount = 1;
						item.rewardCount = 1;
						item.stackable = true;
					});

			JuicyWatermelon.UnlockCost = 10;
			JuicyWatermelon.CostInCharacterCreation = 10;
			JuicyWatermelon.CostInLoadout = 10;

			JuicyWatermelon.UseItem = (item, agent) =>
			{
				if (agent.statusEffects.hasTrait("OilRestoresHealth"))
					agent.SayDialogue("OnlyOilGivesHealth");
				else if (agent.electronic)
					agent.SayDialogue("OnlyChargeGivesHealth");
				else if (agent.statusEffects.hasTrait("CannibalizeRestoresHealth"))
					agent.SayDialogue("OnlyCannibalizeGivesHealth");
				else if (agent.health == agent.healthMax)
					agent.SayDialogue("HealthFullCantUseItem");
				else
				{
					{
						if (agent.statusEffects.hasTrait("BloodRestoresHealth"))
							item.healthChange = 80;
						else
						{
							item.healthChange = 30;
							//agent.statusEffects.AddStatusEffect("Confused" , false , false , 25);
							agent.statusEffects.AddStatusEffect("Incest" , 25);
						}
						int heal = new ItemFunctions().DetermineHealthChange(item, agent);
						agent.statusEffects.ChangeHealth(heal);
						item.database.SubtractFromItemCount(item, 1);
						if (agent.statusEffects.hasTrait("HealthItemsGiveFollowersExtraHealth") || agent.statusEffects.hasTrait("HealthItemsGiveFollowersExtraHealth2"))
							new ItemFunctions().GiveFollowersHealth(agent, heal);
						item.gc.audioHandler.Play(agent, "UseDrink");
						new ItemFunctions().UseItemAnim(item, agent);
					}
					return;
				}
				item.gc.audioHandler.Play(agent, "CantDo");
			};

			#endregion

			#region Steal Apple

			Sprite sprite_9 = RogueUtilities.ConvertToSprite(Properties.Resources.steal_apple);
			CustomItem StealApple = RogueLibs.CreateCustomItem("StealApple", sprite_9, true,
				new CustomNameInfo("Steal apple",
					null, null, null, null,
					"Стальное яблоко", null, null),
					new CustomNameInfo("The latest development of Mech.Food.Industrial and yes.. this apple... steel apple.. The essence is simple when eaten, it envelops the organs and skin with a special alloy that can delay bullets and reduce damage from them. However, it damages the body from the inside..It is useless, isn't it?",
						null, null, null, null,
						"Новейшая разработка Mech.Food.Industrial и да.. это яблоко... стальное яблоко.. Суть проста при съедении обволакивает органы и кожу особым сплавом который способен задерживать пули и снижать ущерб от них. Однако повреждает тело изнутри..Бесполезно, не правда ли?",
						null, null),
					item =>
					{
						item.itemType = "Food";
						item.Categories.Add("Food");
						item.Categories.Add("SMaD");
						item.Categories.Add("Legend");
						item.itemValue = 59;
						item.healthChange = -75;
						item.cantBeCloned = false;
						item.goesInToolbar = true;
						item.initCount = 1;
						item.rewardCount = 1;
						item.stackable = false;
					});

			StealApple.UnlockCost = 15;
			StealApple.CostInCharacterCreation = 15;
			StealApple.CostInLoadout = 15;

			StealApple.UseItem = (item, agent) =>
			{
				if (agent.statusEffects.hasTrait("OilRestoresHealth"))
					agent.SayDialogue("OnlyOilGivesHealth");
				else if (agent.electronic)
					agent.SayDialogue("OnlyChargeGivesHealth");
				else if (agent.statusEffects.hasTrait("CannibalizeRestoresHealth"))
					agent.SayDialogue("OnlyCannibalizeGivesHealth");
				else
				{

					{
						int heal = new ItemFunctions().DetermineHealthChange(item, agent);
						agent.statusEffects.ChangeHealth(heal);
						agent.statusEffects.AddStatusEffect("ResistBullets" , false);
						agent.statusEffects.AddStatusEffect("DecreaseSpeed" , false);
						agent.statusEffects.AddStatusEffect("Steel Apple shell");
						item.database.SubtractFromItemCount(item, 1);
						if (agent.statusEffects.hasTrait("HealthItemsGiveFollowersExtraHealth") || agent.statusEffects.hasTrait("HealthItemsGiveFollowersExtraHealth2"))
							new ItemFunctions().GiveFollowersHealth(agent, heal);
						item.gc.audioHandler.Play(agent, "UseFood");
						new ItemFunctions().UseItemAnim(item, agent);
					}
					return;
				}
				item.gc.audioHandler.Play(agent, "CantDo");
			};

			#endregion

			#region Tentacle Of The Kraken

			Sprite sprite_10 = RogueUtilities.ConvertToSprite(Properties.Resources.tentacle_kraken);
			CustomItem TentacleOfTheKraken = RogueLibs.CreateCustomItem("TentacleOfTheKraken", sprite_10, true,
				new CustomNameInfo("Tentacle of the Kraken",
					null, null, null, null,
					"Щупальце Кракена", null, null),
					new CustomNameInfo("Any Chinese would give a fortune for such a tentacle! What is unique about it? It has strong healing properties,heals all wounds, but gives you a taste of seasickness. Bon Appetit!",
						null, null, null, null,
						"За такое щупальце любой китаец отдал бы состояние! Что в нём уникального? Оно обладая сильными целительными свойствами,залечивает все раны, но даёт вам попробовать на вкус морскую болезнь. Приятного аппетита!",
						null, null),
					item =>
					{
						item.itemType = "Food";
						item.Categories.Add("Food");
						item.Categories.Add("SMaD");
						item.itemValue = 37;
						item.healthChange = 500;
						item.cantBeCloned = false;
						item.goesInToolbar = true;
						item.initCount = 1;
						item.rewardCount = 1;
						item.stackable = true;
					});

			TentacleOfTheKraken.UnlockCost = 10;
			TentacleOfTheKraken.CostInCharacterCreation = 10;
			TentacleOfTheKraken.CostInLoadout = 10;

			TentacleOfTheKraken.UseItem = (item, agent) =>
			{
				if (agent.statusEffects.hasTrait("OilRestoresHealth"))
					agent.SayDialogue("OnlyOilGivesHealth");
				else if (agent.statusEffects.hasTrait("BloodRestoresHealth"))
					agent.SayDialogue("OnlyBloodGivesHealth");
				else if (agent.electronic)
					agent.SayDialogue("OnlyChargeGivesHealth");
				else if (agent.statusEffects.hasTrait("CannibalizeRestoresHealth"))
					agent.SayDialogue("OnlyCannibalizeGivesHealth");
				else if (agent.health == agent.healthMax)
					agent.SayDialogue("HealthFullCantUseItem");
				else
				{

					{
						int heal = new ItemFunctions().DetermineHealthChange(item, agent);
						agent.statusEffects.ChangeHealth(heal);
						//agent.statusEffects.AddStatusEffect("Poisoned" , false, false, 35);
						//agent.statusEffects.AddStatusEffect("Slow" , false , false , 35);
						agent.statusEffects.AddStatusEffect("Seasickness" , 35);
						item.database.SubtractFromItemCount(item, 1);
						if (agent.statusEffects.hasTrait("HealthItemsGiveFollowersExtraHealth") || agent.statusEffects.hasTrait("HealthItemsGiveFollowersExtraHealth2"))
							new ItemFunctions().GiveFollowersHealth(agent, heal);
						item.gc.audioHandler.Play(agent, "UseFood");
						new ItemFunctions().UseItemAnim(item, agent);
					}
					return;
				}
				item.gc.audioHandler.Play(agent, "CantDo");
			};

			#endregion

			#region Divine Honey

			Sprite sprite_11 = RogueUtilities.ConvertToSprite(Properties.Resources.honey);
			CustomItem DivineHoney1 = RogueLibs.CreateCustomItem("DivineHoney", sprite_11, true,
				new CustomNameInfo("Divine Honey",
					null, null, null, null,
					"Божественный Мёд", null, null),
					new CustomNameInfo("This honey was produced by the legendary divine bees, or so the legends say. This honey was obtained in the most insidious way - Stolen. It has effective regenerative abilities, rejuvenates the skin and regenerates lost cells, but it all takes time. Because of the rush during the Assembly of honey, larvae gather in it.",
						null, null, null, null,
						"Этот мед производили легендарные божественных пчелы, по крайней мере так гласят легенды. Этот мёд был добыт самым коварным способом - Украден. Обладает действенными регенерационными способностями, омолаживает кожу и регенерует потерянные клетки, однако это всё занимает время. Из-за спешки во время сборки мёда в нём содержаться личинки.",
						null, null),
					item =>
					{
						item.itemType = "Food";
						item.Categories.Add("Food");
						item.Categories.Add("SMaD");
						item.itemValue = 37;
						item.healthChange = 20;
						item.cantBeCloned = true;
						item.goesInToolbar = true;
						item.initCount = 1;
						item.rewardCount = 1;
						item.stackable = true;
					});

			DivineHoney1.UnlockCost = 12;
			DivineHoney1.CostInCharacterCreation = 12;
			DivineHoney1.CostInLoadout = 12;

			DivineHoney1.UseItem = (item, agent) =>
			{
				if (agent.statusEffects.hasTrait("OilRestoresHealth"))
					agent.SayDialogue("OnlyOilGivesHealth");
				else if (agent.statusEffects.hasTrait("BloodRestoresHealth"))
					agent.SayDialogue("OnlyBloodGivesHealth");
				else if (agent.electronic)
					agent.SayDialogue("OnlyChargeGivesHealth");
				else if (agent.statusEffects.hasTrait("CannibalizeRestoresHealth"))
					agent.SayDialogue("OnlyCannibalizeGivesHealth");
				else if (agent.health == agent.healthMax)
					agent.SayDialogue("HealthFullCantUseItem");
				else
				{

					{
						int heal = new ItemFunctions().DetermineHealthChange(item, agent);
						agent.statusEffects.ChangeHealth(heal);
						//agent.statusEffects.AddStatusEffect("RegenerateHealth", false , false , 60);
						//agent.statusEffects.AddStatusEffect("Paralyzed", false , false , 60);
						agent.statusEffects.AddStatusEffect("Poisoned", false , false , 30);
						agent.statusEffects.AddStatusEffect("Cell regeneration", 60);
						item.database.SubtractFromItemCount(item, 1);
						if (agent.statusEffects.hasTrait("HealthItemsGiveFollowersExtraHealth") || agent.statusEffects.hasTrait("HealthItemsGiveFollowersExtraHealth2"))
							new ItemFunctions().GiveFollowersHealth(agent, heal);
						item.gc.audioHandler.Play(agent, "UseFood");
						new ItemFunctions().UseItemAnim(item, agent);
					}
					return;
				}
				item.gc.audioHandler.Play(agent, "CantDo");
			};

			#endregion

			#region Boompkin

			Sprite sprite_12 = RogueUtilities.ConvertToSprite(Properties.Resources.boom_pump);
			CustomItem Boompkin1 = RogueLibs.CreateCustomItem("Boompkin", sprite_12, true,
				new CustomNameInfo("Boompkin",
					null, null, null, null,
					"Бумква", null, null),
					new CustomNameInfo("Is it just me, or is there something wrong with this pumpkin?",
						null, null, null, null,
						"Мне кажеться или что-то с этой тыквой не так?",
						null, null),
					item =>
					{
						item.itemType = "Food";
						item.Categories.Add("Food");
						item.Categories.Add("SMaD");
						item.Categories.Add("Legend");
						item.itemValue = 57;
						item.healthChange = 0;
						item.cantBeCloned = false;
						item.goesInToolbar = true;
						item.initCount = 1;
						item.rewardCount = 1;
						item.stackable = false;
					});

			Boompkin1.UnlockCost = 5;
			Boompkin1.CostInCharacterCreation = 5;
			Boompkin1.CostInLoadout = 5;

			Boompkin1.UseItem = (item, agent) =>
			{
				if (agent.statusEffects.hasTrait("OilRestoresHealth"))
					agent.SayDialogue("OnlyOilGivesHealth");
				else if (agent.statusEffects.hasTrait("BloodRestoresHealth"))
					agent.SayDialogue("OnlyBloodGivesHealth");
				else if (agent.electronic)
					agent.SayDialogue("OnlyChargeGivesHealth");
				else if (agent.statusEffects.hasTrait("CannibalizeRestoresHealth"))
					agent.SayDialogue("OnlyCannibalizeGivesHealth");
				else
				{

					{
						agent.gc.spawnerMain.SpawnExplosion(agent, agent.tr.position, "Normal", false, -1, false, true).agent = agent;
						agent.gc.spawnerMain.SpawnExplosion(agent, agent.tr.position, "Normal", false, -1, false, true).agent = agent;
						agent.gc.spawnerMain.SpawnExplosion(agent, agent.tr.position, "Normal", false, -1, false, true).agent = agent;
						agent.gc.spawnerMain.SpawnExplosion(agent, agent.tr.position, "Normal", false, -1, false, true).agent = agent;
						agent.gc.spawnerMain.SpawnExplosion(agent, agent.tr.position, "Normal", false, -1, false, true).agent = agent;
						item.database.SubtractFromItemCount(item, 1);
						item.gc.audioHandler.Play(agent, "UseFood");
						new ItemFunctions().UseItemAnim(item, agent);
					}
					return;
				}
				item.gc.audioHandler.Play(agent, "CantDo");
			};

			#endregion

			#region Blood Donut

			Sprite sprite_13 = RogueUtilities.ConvertToSprite(Properties.Resources.donuts_blood);
			CustomItem BloodDonut = RogueLibs.CreateCustomItem("BloodDonut", sprite_13, true,
				new CustomNameInfo("Blood Donut",
					null, null, null, null,
					"Кровавый пончик", null, null),
					new CustomNameInfo("Doughnuts themselves are very nutritious, but only energetically, now imagine that there is a doughnut that will be nutritious for your blood, replenishing the number of red blood cells in it, but this all takes time and it is better not to move during the replenishment of red blood cells.",
						null, null, null, null,
						"Сами по себе пончики очень питательны, но только энергитически, теперь представьте что есть пончик который будет питателен и для вашей крови восполняя количество эритроцитов в ней, однако это всё занимает время и лучше не двигаться во время восполнения эритроцитов.",
						null, null),
					item =>
					{
						item.itemType = "Food";
						item.Categories.Add("Food");
						item.Categories.Add("SMaD");
						item.itemValue = 34;
						item.healthChange = 0;
						item.cantBeCloned = true;
						item.goesInToolbar = true;
						item.initCount = 1;
						item.rewardCount = 3;
						item.stackable = true;
					});

			BloodDonut.UnlockCost = 10;
			BloodDonut.CostInCharacterCreation = 10;
			BloodDonut.CostInLoadout = 10;

			BloodDonut.UseItem = (item, agent) =>
			{
				if (agent.statusEffects.hasTrait("OilRestoresHealth"))
					agent.SayDialogue("OnlyOilGivesHealth");
				else if (agent.electronic)
					agent.SayDialogue("OnlyChargeGivesHealth");
				else if (agent.statusEffects.hasTrait("CannibalizeRestoresHealth"))
					agent.SayDialogue("OnlyCannibalizeGivesHealth");
				else
				{

					{
						item.database.SubtractFromItemCount(item, 1);
						//agent.statusEffects.AddStatusEffect("RegenerateHealth" , false , false , 60);
						//agent.statusEffects.AddStatusEffect("Paralyzed" , false , false , 60);
						agent.statusEffects.AddStatusEffect("Red blood cell replenishment" , 60);
						item.gc.audioHandler.Play(agent, "UseFood");
						new ItemFunctions().UseItemAnim(item, agent);
					}
					return;
				}
				item.gc.audioHandler.Play(agent, "CantDo");
			};

			#endregion

			#region Fish oil

			Sprite sprite_14 = RogueUtilities.ConvertToSprite(Properties.Resources.fish_fat);
			CustomItem Fishoil = RogueLibs.CreateCustomItem("Fishoil", sprite_14, true,
				new CustomNameInfo("Fish oil",
					null, null, null, null,
					"Рыбий жир", null, null),
					new CustomNameInfo("Fish oil - as scientists have proven a very useful thing, although people are not completely sure about it. its taste and color are known to many,but few people know that it can restore the cells of human organs, as well as increase your strength, but it is quite a heavy product so that a run is not fatal for you..but still it is not desirable to run. But you did not listen to your mother and did not eat fish oil as a child, even in the game eat.",
						null, null, null, null,
						"Рыбий жир - как доказали ученые очень полезная вещь, хотя люди не до конца уверены в этом. его вкус и цвет известен многим,однако мало кто знает что он может восстанавливать клетки человеческих органов, так же увеличивает  вашу силу, но он достаточно тяжёлый продукт так что пробежка для вас не смертельна..но всё таки бегать не желательно. А вы вот не слушались маму и не ели рыбий жир в детстве, хоть в игре поешьте.",
						null, null),
					item =>
					{
						item.itemType = "Food";
						item.Categories.Add("Food");
						item.Categories.Add("SMaD");
						item.itemValue = 23;
						item.healthChange = 25;
						item.cantBeCloned = true;
						item.goesInToolbar = true;
						item.initCount = 1;
						item.rewardCount = 3;
						item.stackable = true;
					});

			Fishoil.UnlockCost = 10;
			Fishoil.CostInCharacterCreation = 10;
			Fishoil.CostInLoadout = 10;

			Fishoil.UseItem = (item, agent) =>
			{
				if (agent.statusEffects.hasTrait("OilRestoresHealth"))
					agent.SayDialogue("OnlyOilGivesHealth");
				else if (agent.statusEffects.hasTrait("BloodRestoresHealth"))
					agent.SayDialogue("OnlyBloodGivesHealth");
				else if (agent.electronic)
					agent.SayDialogue("OnlyChargeGivesHealth");
				else if (agent.statusEffects.hasTrait("CannibalizeRestoresHealth"))
					agent.SayDialogue("OnlyCannibalizeGivesHealth");
				else
				{

					{
						item.database.SubtractFromItemCount(item, 1);
						//agent.statusEffects.AddStatusEffect("Strength", false, false, 25);
						//agent.statusEffects.AddStatusEffect("Slow", false , false , 25);
						agent.statusEffects.AddStatusEffect("The power of Fish Oil", 25);
						item.gc.audioHandler.Play(agent, "UseFood");
						new ItemFunctions().UseItemAnim(item, agent);
					}
					return;
				}
				item.gc.audioHandler.Play(agent, "CantDo");
			};

			#endregion

			#region Chak Chak

			Sprite sprite_15 = RogueUtilities.ConvertToSprite(Properties.Resources.aroct_chak_chak);
			CustomItem ChakChak = RogueLibs.CreateCustomItem("ChakChak", sprite_15, true,
				new CustomNameInfo("Chak-chak",
					null, null, null, null,
					"Чак-чак", null, null),
					new CustomNameInfo("Imagine bread pasta in a decent amount of honey. Presented? Well, it's chak-chak, sticky.. tasty.. however, this is a special issue, unfortunately everyone who eats it will instantly go berserk, it's good that it will be easy to escape from them chak-chak-something sticky.",
						null, null, null, null,
						"Представьте себе хлебные макароны в приличном количестве мёда. Представили? Ну так это Чак-чак, липкий.. вкусный.. однако это специальный выпуск, к сожалению все кто съедят его мгновенно озвереют, хорошо что от них будет легко убежать Чак-чак-то липкий.",
						null, null),
					item =>
					{
						item.itemType = "Food";
						item.Categories.Add("Food");
						item.Categories.Add("SMaD");
						item.Categories.Add("FF");
						item.itemValue = 63;
						item.healthChange = 20;
						item.cantBeCloned = true;
						item.goesInToolbar = true;
						item.initCount = 1;
						item.rewardCount = 1;
						item.stackable = true;
					});

			ChakChak.UnlockCost = 12;
			ChakChak.CostInCharacterCreation = 12;
			ChakChak.CostInLoadout = 12;

			ChakChak.UseItem = (item, agent) =>
			{
				if (agent.statusEffects.hasTrait("OilRestoresHealth"))
					agent.SayDialogue("OnlyOilGivesHealth");
				else if (agent.statusEffects.hasTrait("BloodRestoresHealth"))
					agent.SayDialogue("OnlyBloodGivesHealth");
				else if (agent.electronic)
					agent.SayDialogue("OnlyChargeGivesHealth");
				else if (agent.statusEffects.hasTrait("CannibalizeRestoresHealth"))
					agent.SayDialogue("OnlyCannibalizeGivesHealth");
				else
				{

					{
						item.database.SubtractFromItemCount(item, 1);
						//agent.statusEffects.AddStatusEffect("Enraged", false, false, 50);
						//agent.statusEffects.AddStatusEffect("Slow", false, false, 50);
						//agent.statusEffects.AddStatusEffect("AlwaysCrit", false , false , 50);
						agent.statusEffects.AddStatusEffect("Sticky enrage", 50);
						item.gc.audioHandler.Play(agent, "UseFood");
						new ItemFunctions().UseItemAnim(item, agent);
					}
					return;
				}
				item.gc.audioHandler.Play(agent, "CantDo");
			};

			#endregion

			#region Crepe Mushroom

			Sprite sprite_16 = RogueUtilities.ConvertToSprite(Properties.Resources.blind_mushroom);
			CustomItem CrepeMushroom = RogueLibs.CreateCustomItem("CrepeMushroom", sprite_16, true,
				new CustomNameInfo("Crepe Mushroom",
					null, null, null, null,
					"Блино-Гриб", null, null),
					new CustomNameInfo("Everyone's favorite mushroom from the game SUPER-CREPE. Feel yourself Super-Crepe.",
						null, null, null, null,
						"Всеми любимый гриб из игры СУПЕР-БЛИН. Почувствуйте себя Супер-Блином.",
						null, null),
					item =>
					{
						item.itemType = "Food";
						item.Categories.Add("Food");
						item.Categories.Add("SMaD");
						item.Categories.Add("PashalOchka");
						item.itemValue = 57;
						item.healthChange = 15;
						item.cantBeCloned = false;
						item.goesInToolbar = true;
						item.initCount = 1;
						item.rewardCount = 1;
						item.stackable = false;
					});

			CrepeMushroom.UnlockCost = 12;
			CrepeMushroom.CostInCharacterCreation = 12;
			CrepeMushroom.CostInLoadout = 12;

			CrepeMushroom.UseItem = (item, agent) =>
			{
				if (agent.statusEffects.hasTrait("OilRestoresHealth"))
					agent.SayDialogue("OnlyOilGivesHealth");
				else if (agent.statusEffects.hasTrait("BloodRestoresHealth"))
					agent.SayDialogue("OnlyBloodGivesHealth");
				else if (agent.electronic)
					agent.SayDialogue("OnlyChargeGivesHealth");
				else if (agent.statusEffects.hasTrait("CannibalizeRestoresHealth"))
					agent.SayDialogue("OnlyCannibalizeGivesHealth");
				else
				{

					{
						item.database.SubtractFromItemCount(item, 1);
						//agent.statusEffects.AddStatusEffect("Invincible", false , false , 25);
						agent.statusEffects.AddStatusEffect("Nostalgia", 25); 
						item.gc.audioHandler.Play(agent, "UseFood");
						new ItemFunctions().UseItemAnim(item, agent);
					}
					return;
				}
				item.gc.audioHandler.Play(agent, "CantDo");
			};

			#endregion

			#region Tear of Heaven

			Sprite sprite_18 = RogueUtilities.ConvertToSprite(Properties.Resources.tears_of_heaven);
			CustomItem TearofHeaven = RogueLibs.CreateCustomItem("TearofHeaven", sprite_18, true,
				new CustomNameInfo("Tear of Heaven",
					null, null, null, null,
					"Слезы Небес", null, null),
					new CustomNameInfo("Heaven's tears are granted if the gods like your soul. A person who receives the Tears of Heaven at a critical moment can drink them to get even temporary, but the power of God, and restore the body, but his body is not able to withstand the power of the gods,which is why it is not able to move.",
						null, null, null, null,
						"Слезы Небес даруются, если богам понравилась твоя душа. Человек получивший Слезы Небес в критический момент может выпить их что бы получить пускай и временную, но силу бога, и восстановить организм, однако его тело не способно выдержать мощь богов из-за чего не способно двигаться.",
						null, null),
					item =>
					{
						item.itemType = "Food";
						item.Categories.Add("Food");
						item.Categories.Add("SMaD");
						item.Categories.Add("Legend");
						item.itemValue = 127;
						item.healthChange = 99999;
						item.cantBeCloned = false;
						item.goesInToolbar = true;
						item.initCount = 1;
						item.rewardCount = 1;
						item.stackable = false;
					});

			TearofHeaven.UnlockCost = 20;
			TearofHeaven.CostInCharacterCreation = 20;
			TearofHeaven.CostInLoadout = 20;

			TearofHeaven.UseItem = (item, agent) =>
			{
				if (agent.statusEffects.hasTrait("OilRestoresHealth"))
					agent.SayDialogue("OnlyOilGivesHealth");
				else if (agent.statusEffects.hasTrait("BloodRestoresHealth"))
					agent.SayDialogue("OnlyBloodGivesHealth");
				else if (agent.electronic)
					agent.SayDialogue("OnlyChargeGivesHealth");
				else if (agent.statusEffects.hasTrait("CannibalizeRestoresHealth"))
					agent.SayDialogue("OnlyCannibalizeGivesHealth");
				else
				{

					{
						item.database.SubtractFromItemCount(item, 1);
						//agent.statusEffects.AddStatusEffect("Invincible", false , false, 35);
						//agent.statusEffects.AddStatusEffect("Paralyzed", false , false , 35);
						agent.statusEffects.AddStatusEffect("The Tears of Heaven are drunk", 35);
						item.gc.audioHandler.Play(agent, "UseDrink");
						new ItemFunctions().UseItemAnim(item, agent);
					}
					return;
				}
				item.gc.audioHandler.Play(agent, "CantDo");
			};


			#endregion

			#region Brain Jellyfish

			Sprite sprite_19 = RogueUtilities.ConvertToSprite(Properties.Resources.brain_jellyfish);
			CustomItem BrainJellyfish = RogueLibs.CreateCustomItem("BrainJellyfish", sprite_19, true,
				new CustomNameInfo("Brain jellyfish",
					null, null, null, null,
					"Мозговая медуза", null, null),
					new CustomNameInfo("A fairly decent-sized jellyfish that can control the host's brain, transmitting its properties to the host's body, even if not for long.",
						null, null, null, null,
						"Достаточно приличных размеров медуза способная контролировать мозг носителя, передавая свои свойства телу носителя пускай и не надолго.",
						null, null),
					item =>
					{
						item.itemType = "Food";
						item.Categories.Add("Food");
						item.Categories.Add("SMaD");
						item.Categories.Add("Legend");
						item.itemValue = 57;
						item.healthChange = -15;
						item.cantBeCloned = true;
						item.goesInToolbar = true;
						item.initCount = 1;
						item.rewardCount = 1;
						item.stackable = true;
					});

			BrainJellyfish.UnlockCost = 10;
			BrainJellyfish.CostInCharacterCreation = 10;
			BrainJellyfish.CostInLoadout = 10;

			BrainJellyfish.UseItem = (item, agent) =>
			{
				if (agent.statusEffects.hasTrait("OilRestoresHealth"))
					agent.SayDialogue("OnlyOilGivesHealth");
				else if (agent.electronic)
					agent.SayDialogue("OnlyChargeGivesHealth");
				else
				{
					{
						//agent.statusEffects.AddStatusEffect("Enraged", false, false, 20);
						//agent.statusEffects.AddStatusEffect("ElectroTouch", false , false , 20);
						agent.statusEffects.AddStatusEffect("Controlled by Brain Jellyfish", 20);
						item.database.SubtractFromItemCount(item, 1);
						item.gc.audioHandler.Play(agent, "UseFood");
						new ItemFunctions().UseItemAnim(item, agent);
					}
					return;
				}
				item.gc.audioHandler.Play(agent, "CantDo");
			};

			#endregion

			#region Medical Carp caviar

			Sprite sprite_20 = RogueUtilities.ConvertToSprite(Properties.Resources.caviar_medical_carp);
			CustomItem MedicalCarpcaviar = RogueLibs.CreateCustomItem("MedicalCarpcaviar", sprite_20, true,
				new CustomNameInfo("Medical Carp caviar",
					null, null, null, null,
					"Икра Медицинского Карася", null, null),
					new CustomNameInfo("Medical crucian carp is a rare fish, and its caviar is incredibly valuable in medicine, every doctor dreams of it like this! When ingested, it destroys all foreign bodies in the body, do not forget to spit!",
						null, null, null, null,
						"Медицинский карась редчайшая рыба, а её икра невероятно ценна в медицине, каждый врач мечтает о ней таком! При попадании в организм уничтожает все чужеродные тела в организме, не забудьте сплюнуть!",
						null, null),
					item =>
					{
						item.itemType = "Food";
						item.Categories.Add("Food");
						item.Categories.Add("SMaD");
						item.Categories.Add("Legend");
						item.itemValue = 43;
						item.healthChange = 0;
						item.cantBeCloned = true;
						item.goesInToolbar = true;
						item.initCount = 1;
						item.rewardCount = 1;
						item.stackable = true;
					});

			MedicalCarpcaviar.UnlockCost = 8;
			MedicalCarpcaviar.CostInCharacterCreation = 8;
			MedicalCarpcaviar.CostInLoadout = 8;

			MedicalCarpcaviar.UseItem = (item, agent) =>
			{
				if (agent.statusEffects.hasTrait("OilRestoresHealth"))
					agent.SayDialogue("OnlyOilGivesHealth");
				else if (agent.statusEffects.hasTrait("BloodRestoresHealth"))
					agent.SayDialogue("OnlyBloodGivesHealth");
				else if (agent.electronic)
					agent.SayDialogue("OnlyChargeGivesHealth");
				else if (agent.statusEffects.hasTrait("CannibalizeRestoresHealth"))
					agent.SayDialogue("OnlyCannibalizeGivesHealth");
				else
				{
					{
						agent.statusEffects.RemoveAllStatusEffects();
						item.database.SubtractFromItemCount(item, 1);
						item.gc.audioHandler.Play(agent, "UseAntidot");
						new ItemFunctions().UseItemAnim(item, agent);
					}
					return;
				}
				item.gc.audioHandler.Play(agent, "CantDo");
			};

			#endregion

			#region Fire Salamander heart

			Sprite sprite_21 = RogueUtilities.ConvertToSprite(Properties.Resources.salamandr_heart);
			CustomItem FireSalamanderheart = RogueLibs.CreateCustomItem("FireSalamanderheart", sprite_21, true,
				new CustomNameInfo("Fire Salamander heart",
					null, null, null, null,
					"Сердце Огненной Саламандры", null, null),
					new CustomNameInfo("The Salamander heart is an incredibly nasty-tasting organ that pumps blood. I do not think that you need to eat it, although if you are a Pyromancer, it is your best friend, because your blood is saturated with special cells and will spread them throughout the body and you will become less vulnerable to fire. These cells are able to adapt quickly, it is a pity that your body will not accept them immediately.. so that.. Good luck surviving the War inside your body!",
						null, null, null, null,
						"Саламандровское сердце - невероятно противный на вкус орган качающий кровь. Не думаю что нужно его есть, хотя если вы пиромант то это ваш лучший друг, ведь ваша кровь насытиться особыми клетками и разнесёт их по всему организму и вы станете менее уязвима к огню. Эти клетки умеют быстро адаптироваться, жаль что ваш организм не примет их сразу.. так что.. Удачи вам пережить Войну внутри вашего организма!",
						null, null),
					item =>
					{
						item.itemType = "Food";
						item.Categories.Add("Food");
						item.Categories.Add("SMaD");
						item.Categories.Add("Legend");
						item.itemValue = 73;
						item.healthChange = -80;
						item.cantBeCloned = false;
						item.goesInToolbar = true;
						item.initCount = 1;
						item.rewardCount = 1;
						item.stackable = false;
					});

			FireSalamanderheart.UnlockCost = 15;
			FireSalamanderheart.CostInCharacterCreation = 15;
			FireSalamanderheart.CostInLoadout = 15;

			FireSalamanderheart.UseItem = (item, agent) =>
			{
				if (agent.statusEffects.hasTrait("OilRestoresHealth"))
					agent.SayDialogue("OnlyOilGivesHealth");
				else if (agent.electronic)
					agent.SayDialogue("OnlyChargeGivesHealth");
				else if (agent.statusEffects.hasTrait("CannibalizeRestoresHealth"))
					agent.SayDialogue("OnlyCannibalizeGivesHealth");
				else
				{

					{
						int heal = new ItemFunctions().DetermineHealthChange(item, agent);
						agent.statusEffects.ChangeHealth(heal);
						//agent.statusEffects.AddStatusEffect("ResistFire" , false);
						agent.statusEffects.AddStatusEffect("Second heart");
						item.database.SubtractFromItemCount(item, 1);
						if (agent.statusEffects.hasTrait("HealthItemsGiveFollowersExtraHealth") || agent.statusEffects.hasTrait("HealthItemsGiveFollowersExtraHealth2"))
							new ItemFunctions().GiveFollowersHealth(agent, heal);
						item.gc.audioHandler.Play(agent, "UseFood");
						new ItemFunctions().UseItemAnim(item, agent);
					}
					return;
				}
				item.gc.audioHandler.Play(agent, "CantDo");
			};

			#endregion

			#region Wine Drunk Cherry 

			Sprite sprite_22 = RogueUtilities.ConvertToSprite(Properties.Resources.drunk_cherry_wine);
			CustomItem WineDrunkCherry = RogueLibs.CreateCustomItem("WineDrunkCherry", sprite_22, true,
				new CustomNameInfo("Wine Drunk Cherry",
					null, null, null, null,
					"Вино Пьяная Вишня", null, null),
					new CustomNameInfo("Wine made from drunk cherries contains the maximum allowed degree. Drunk cherry is an incredibly rare fruit, I think it is not necessary to explain that you will get drunk in the trash and will be very sober for a long time.",
						null, null, null, null,
						"Вино из пьяной вишни содержит максимально допустимый градус. Пьяная вишня невероятно редкий фрукт, думаю не стоит объяснять что вы напьётесь в хлам и будете очень долго трезветь.",
						null, null),
					item =>
					{
						item.itemType = "Food";
						item.Categories.Add("Alcohol");
						item.Categories.Add("SMaD");
						item.itemValue = 37;
						item.healthChange = 40;
						item.cantBeCloned = true;
						item.goesInToolbar = true;
						item.initCount = 1;
						item.rewardCount = 1;
						item.stackable = true;
					});

			WineDrunkCherry.UnlockCost = 12;
			WineDrunkCherry.CostInCharacterCreation = 12;
			WineDrunkCherry.CostInLoadout = 12;

			WineDrunkCherry.UseItem = (item, agent) =>
			{
				if (agent.statusEffects.hasTrait("OilRestoresHealth"))
					agent.SayDialogue("OnlyOilGivesHealth");
				else if (agent.statusEffects.hasTrait("BloodRestoresHealth"))
					agent.SayDialogue("OnlyBloodGivesHealth");
				else if (agent.electronic)
					agent.SayDialogue("OnlyChargeGivesHealth");
				else if (agent.statusEffects.hasTrait("CannibalizeRestoresHealth"))
					agent.SayDialogue("OnlyCannibalizeGivesHealth");
				else if (agent.health == agent.healthMax)
					agent.SayDialogue("HealthFullCantUseItem");
				else
				{

					{
						int heal = new ItemFunctions().DetermineHealthChange(item, agent);
						agent.statusEffects.ChangeHealth(heal);
						//agent.statusEffects.AddStatusEffect("Slow", false, false, 60);
						//agent.statusEffects.AddStatusEffect("Confused", false, false, 60);
						//agent.statusEffects.AddStatusEffect("Strength", false , false , 60);
						agent.statusEffects.AddStatusEffect("Drunk1", 60);
						item.database.SubtractFromItemCount(item, 1);
						if (agent.statusEffects.hasTrait("HealthItemsGiveFollowersExtraHealth") || agent.statusEffects.hasTrait("HealthItemsGiveFollowersExtraHealth2"))
							new ItemFunctions().GiveFollowersHealth(agent, heal);
						item.gc.audioHandler.Play(agent, "Drink");
						new ItemFunctions().UseItemAnim(item, agent);

					}
					return;
				}
				item.gc.audioHandler.Play(agent, "CantDo");
			};

			#endregion

			#region Alien rations

			Sprite sprite_23 = RogueUtilities.ConvertToSprite(Properties.Resources.alien_rations);
			CustomItem Alienrations = RogueLibs.CreateCustomItem("Alienrations", sprite_23, true,
				new CustomNameInfo("Alien rations",
					null, null, null, null,
					"Паёк пришельцев", null, null),
					new CustomNameInfo("The ration came from a planet unknown to anyone, few people know about it, even fewer have tried it. Completely tasteless and odorless, not even nutritious, but after a while the taster will feel a surge of strength and not only.",
						null, null, null, null,
						"Паек прибыл с неизвестной никому планеты, мало кто знает об этом, ещё меньше пробовали. Полностью безвкусен и не имеет запаха, даже не питателен,  но через некоторое время попробовавший почувствует прилив сил и не только.",
						null, null),
					item =>
					{
						item.itemType = "Food";
						item.Categories.Add("Food");
						item.Categories.Add("SMaD");
						item.Categories.Add("Legend");
						item.itemValue = 0;
						item.healthChange = 0;
						item.cantBeCloned = true;
						item.goesInToolbar = true;
						item.initCount = 1;
						item.rewardCount = 1;
						item.stackable = true;
						//item.addStatusEffectFromContents
					});

			Alienrations.UnlockCost = 15;
			Alienrations.CostInCharacterCreation = 15;
			Alienrations.CostInLoadout = 15;

			Alienrations.UseItem = (item, agent) =>
			{
				if (agent.statusEffects.hasTrait("OilRestoresHealth"))
					agent.SayDialogue("OnlyOilGivesHealth");
				else if (agent.statusEffects.hasTrait("BloodRestoresHealth"))
					agent.SayDialogue("OnlyBloodGivesHealth");
				else if (agent.electronic)
					agent.SayDialogue("OnlyChargeGivesHealth");
				else if (agent.statusEffects.hasTrait("CannibalizeRestoresHealth"))
					agent.SayDialogue("OnlyCannibalizeGivesHealth");
				else
				{

					{
						int heal = new ItemFunctions().DetermineHealthChange(item, agent);
						agent.statusEffects.ChangeHealth(heal);
						//agent.statusEffects.AddStatusEffect("IncreaseSpeed", false ,true);
						//agent.statusEffects.AddStatusEffect("IncreaseStrength", false , true);
						agent.statusEffects.AddStatusEffect("Alien ration was eaten");
						agent.statusEffects.RemoveStatusEffect("DecreaseSpeed");
						agent.statusEffects.RemoveStatusEffect("DecreaseStrength");
						item.database.SubtractFromItemCount(item, 1);
						item.gc.audioHandler.Play(agent, "UseFood");
						new ItemFunctions().UseItemAnim(item, agent);
					}
					return;
				}
				item.gc.audioHandler.Play(agent, "CantDo");
			};

			#endregion

			#region JoCake

			Sprite sprite_24 = RogueUtilities.ConvertToSprite(Properties.Resources.jocake);
			CustomItem JoCake = RogueLibs.CreateCustomItem("JoCake", sprite_24, true,
				new CustomNameInfo("JoCake",
					null, null, null, null,
					"Шуторт", null, null),
					new CustomNameInfo("This cake was made by 3 unknown comedians, being very fat and nutritious makes the eater immediately make a joke. The party with these cakes will be very fun!",
						null, null, null, null,
						"Этот торт был изготовлен 3 неизвестными комиками, будучи весьма жирный и питательный заставляет съевшего немедленно пошутить. Вечеринка с такими тортами будет очень веселая!",
						null, null),
					item =>
					{
						item.itemType = "Food";
						item.Categories.Add("Food");
						item.Categories.Add("SMaD");
						item.Categories.Add("Legend");
						item.itemValue = 53;
						item.healthChange = 45;
						item.cantBeCloned = true;
						item.goesInToolbar = true;
						item.initCount = 1;
						item.rewardCount = 1;
						item.stackable = true;
						//item.addStatusEffectFromContents
					});

			JoCake.UnlockCost = 15;
			JoCake.CostInCharacterCreation = 15;
			JoCake.CostInLoadout = 15;

			JoCake.UseItem = (item, agent) =>
			{
				if (agent.statusEffects.hasTrait("OilRestoresHealth"))
					agent.SayDialogue("OnlyOilGivesHealth");
				else if (agent.statusEffects.hasTrait("BloodRestoresHealth"))
					agent.SayDialogue("OnlyBloodGivesHealth");
				else if (agent.electronic)
					agent.SayDialogue("OnlyChargeGivesHealth");
				else if (agent.statusEffects.hasTrait("CannibalizeRestoresHealth"))
					agent.SayDialogue("OnlyCannibalizeGivesHealth");
				else if (agent.health == agent.healthMax)
					agent.SayDialogue("HealthFullCantUseItem");
				else
				{

					{
						int heal = new ItemFunctions().DetermineHealthChange(item, agent);
						agent.statusEffects.ChangeHealth(heal);
						string prev = agent.specialAbility;
						agent.specialAbility = "Joke";
						agent.statusEffects.PressedSpecialAbility();
						agent.statusEffects.PressedSpecialAbility();
						agent.statusEffects.PressedSpecialAbility();
						agent.statusEffects.PressedSpecialAbility();
						agent.statusEffects.PressedSpecialAbility();
						agent.statusEffects.PressedSpecialAbility();
						agent.specialAbility = prev;
						item.database.SubtractFromItemCount(item, 1);
						item.gc.audioHandler.Play(agent, "UseFood");
						new ItemFunctions().UseItemAnim(item, agent);
					}
					return;
				}
				item.gc.audioHandler.Play(agent, "CantDo");
			};

			#endregion

			#region Nuclear Barrel

			Sprite sprite_25 = RogueUtilities.ConvertToSprite(Properties.Resources.acid_bochka);
			CustomItem Nuclearbarrel = RogueLibs.CreateCustomItem("Nuclearbarrel", sprite_25, true,
				new CustomNameInfo("Nuclear barrel",
					null, null, null, null,
					"Бочка с ядерными отходами", null, null),
					new CustomNameInfo("Similar waste was found at one of the illegal production facilities in the Park. I don't think you should explain what to drink... extremely dangerous!",
						null, null, null, null,
						"Похожие отходы были найдены на одном из нелегальных производств в Парке это как-то связано.. думаю не стоит объяснять что пить такое... крайне опасно!",
						null, null),
					item =>
					{
						item.itemType = "Food";
						item.Categories.Add("Alcohol");
						item.Categories.Add("SMaD");
						item.Categories.Add("Legend");
						item.itemValue = 112;
						item.healthChange = 0;
						item.cantBeCloned = true;
						item.goesInToolbar = true;
						item.initCount = 1;
						item.rewardCount = 1;
						item.stackable = false;
						//item.addStatusEffectFromContents
					});

			Nuclearbarrel.UnlockCost = 15;
			Nuclearbarrel.CostInCharacterCreation = 15;
			Nuclearbarrel.CostInLoadout = 15;

			Nuclearbarrel.UseItem = (item, agent) =>
			{
				if (agent.statusEffects.hasTrait("OilRestoresHealth"))
					agent.SayDialogue("OnlyOilGivesHealth");
				else if (agent.electronic)
					agent.SayDialogue("OnlyChargeGivesHealth");
				else
				{

					{
						//agent.statusEffects.AddStatusEffect("Acid", false, false, 25);
						//agent.statusEffects.AddStatusEffect("Slow", false, false, 25);
						//agent.statusEffects.AddStatusEffect("Poisoned", false, false, 25);
						//agent.statusEffects.AddStatusEffect("Confused", false, false, 25);
						agent.statusEffects.AddStatusEffect("Nuclear Barrel was drunk", 25);
						//string objectSource = SlimePuddle;
						item.gc.spawnerMain.spawnObjectReal(agent.tr.position , null , "SlimePuddle");
						item.database.SubtractFromItemCount(item, 1);
						item.gc.audioHandler.Play(agent, "UseDrink");
						new ItemFunctions().UseItemAnim(item, agent);
					}
					return;
				}
				item.gc.audioHandler.Play(agent, "CantDo");
			};

			#endregion

			#region Nuclear spaghetti

			Sprite sprite_26 = RogueUtilities.ConvertToSprite(Properties.Resources.acid_spaggety);
			CustomItem Nuclearspaghetti = RogueLibs.CreateCustomItem("Nuclearspaghetti", sprite_26, true,
				new CustomNameInfo("Nuclear spaghetti",
					null, null, null, null,
					"Ядерные спагетти", null, null),
					new CustomNameInfo("There is a pattern here.. they were also made in the Park.. and most likely on one of the illegal productions.. Hmm apparently they are not so much soaked in waste I think.. you can eat.. but again, not desirable..",
						null, null, null, null,
						"Здесь есть какая-то закономерность.. они тоже были изготовлены в Парке.. и скорее всего на одном из нелегальных производст.. Хм судя по всему они не столь сильно пропитались отходами думаю.. есть можно.. но опять же не желательно..",
						null, null),
					item =>
					{
						item.itemType = "Food";
						item.Categories.Add("Alcohol");
						item.Categories.Add("SMaD");
						item.Categories.Add("Legend");
						item.itemValue = 112;
						item.healthChange = 500;
						item.cantBeCloned = true;
						item.goesInToolbar = true;
						item.initCount = 1;
						item.rewardCount = 1;
						item.stackable = false;
						//item.addStatusEffectFromContents
					});

			Nuclearspaghetti.UnlockCost = 15;
			Nuclearspaghetti.CostInCharacterCreation = 15;
			Nuclearspaghetti.CostInLoadout = 15;

			Nuclearspaghetti.UseItem = (item, agent) =>
			{
				if (agent.statusEffects.hasTrait("OilRestoresHealth"))
					agent.SayDialogue("OnlyOilGivesHealth");
				else if (agent.electronic)
					agent.SayDialogue("OnlyChargeGivesHealth");
				else
				{

					{
						int heal = new ItemFunctions().DetermineHealthChange(item, agent);
						agent.statusEffects.ChangeHealth(heal);
						//agent.statusEffects.AddStatusEffect("Acid" , false , false , 25);
						//agent.statusEffects.AddStatusEffect("Poisoned" , false, false, 25);
						agent.statusEffects.AddStatusEffect("Nuclear spaghetti was eaten", 25);
						item.database.SubtractFromItemCount(item, 1);
						item.gc.audioHandler.Play(agent, "UseDrink");
						new ItemFunctions().UseItemAnim(item, agent);
					}
					return;
				}
				item.gc.audioHandler.Play(agent, "CantDo");
			};

			#endregion

			#endregion

			/*#region Test Item

			Sprite sprite_17 = RogueUtilities.ConvertToSprite(Properties.Resources.blind_mushroom);
			CustomItem TestItem = RogueLibs.CreateCustomItem("TestItem", sprite_17, true,
				new CustomNameInfo("TestItem",
					null, null, null, null,
					"Тестовый предмет", null, null),
					new CustomNameInfo("Test item.",
						null, null, null, null,
						"Тестовый предмет.",
						null, null),
					item =>
					{
						item.itemType = "Food";
						item.Categories.Add("Food");
						item.Categories.Add("SMaD");
						item.Categories.Add("Test");
						item.itemValue = 0;
						item.healthChange = 0;
						item.cantBeCloned = true;
						item.goesInToolbar = true;
						item.initCount = 20;
						item.rewardCount = 20;
						item.stackable = true;
					});

			TestItem.UnlockCost = 0;
			TestItem.CostInCharacterCreation = 0;
			TestItem.CostInLoadout = 0;

			TestItem.UseItem = (item, agent) =>
			{
				if (agent.statusEffects.hasTrait("OilRestoresHealth"))
					agent.SayDialogue("OnlyOilGivesHealth");
				else if (agent.electronic)
					agent.SayDialogue("OnlyChargeGivesHealth");
				else
				{

					{
						item.gc.audioHandler.Play(agent, "UseFood");
						new ItemFunctions().UseItemAnim(item, agent);
						string effect = "Gas";
						item.gc.spawnerMain.SpawnParticleEffect(effect, agent.tr.position, 90f);
						item.gc.spawnerMain.SpawnParticleEffect(effect, agent.tr.position, 10);
					}
					return;
				}
				item.gc.audioHandler.Play(agent, "CantDo");
			};

			#endregion*/
		}

        #region Patches
        public static void RandomItems_fillItems(RandomItems __instance)
		{
			RandomSelection sel = GameObject.Find("ScriptObject").GetComponent<RandomSelection>();
			
			RandomList rList = sel.randomListTable["Food1"];
			sel.CreateRandomElement(rList, "KCDrink", 6);
			sel.CreateRandomElement(rList, "WineDrunkCherry", 5);
			sel.CreateRandomElement(rList, "BOOMCorn", 4);
			rList = sel.randomListTable["Food2"];
			sel.CreateRandomElement(rList, "CIceCream", 4);
			sel.CreateRandomElement(rList, "JuicyWatermelon", 3);
			sel.CreateRandomElement(rList, "TentacleOfTheKraken", 2);
			sel.CreateRandomElement(rList, "Fishoil", 4);
			sel.CreateRandomElement(rList, "ChakChak", 3); 
			sel.CreateRandomElement(rList, "BloodDonut", 5);
			sel.CreateRandomElement(rList, "Boompkin", 4);
			sel.CreateRandomElement(rList, "DivineHoney", 3);
			sel.CreateRandomElement(rList, "BotexLeg", 4);
			sel.CreateRandomElement(rList, "StealApple", 1);
			sel.CreateRandomElement(rList, "FishOfLuck", 1);
			sel.CreateRandomElement(rList, "BrainJellyfish", 3);
			sel.CreateRandomElement(rList, "MedicalCarpcaviar", 3);
			sel.CreateRandomElement(rList, "FireSalamanderheart", 2);
			sel.CreateRandomElement(rList, "Nuclearspaghetti", 2);
			sel.CreateRandomElement(rList, "Nuclearbarrel", 3);
			sel.CreateRandomElement(rList, "JoCake", 3);







		}

		public static void StatusEffects_hasStatusEffect(StatusEffects __instance, string statusEffectName, ref bool __result)
		{
			#region Nostalgia
			if (statusEffectName == "Invincible" && __instance.hasStatusEffect("Nostalgia"))
				__result = true;
			#endregion

            #region Seasickness
            if (statusEffectName == "Slow" && __instance.hasStatusEffect("Seasickness"))
					__result = true;
			#endregion

			#region Temporary excess weight
			if (statusEffectName == "Slow" && __instance.hasStatusEffect("Temporary excess weight"))
					__result = true;
			if (statusEffectName == "Giant" && __instance.hasStatusEffect("Temporary excess weight"))
					__result = true;
			#endregion

			#region Incest
			if (statusEffectName == "Confused" && __instance.hasStatusEffect("Incest"))
					__result = true;
			#endregion

			#region Steel Apple shell
			if (statusEffectName == "ResistBullets" && __instance.hasStatusEffect("Steel Apple shell"))
					__result = true;
			if (statusEffectName == "DecreaseSpeed" && __instance.hasStatusEffect("Steel Apple shell"))
					__result = true;
			#endregion

			#region Cell regeneration
			if (statusEffectName == "RegenerateHealth" && __instance.hasStatusEffect("Cell regeneration"))
					__result = true;
			if (statusEffectName == "Paralyzed" && __instance.hasStatusEffect("Cell regeneration"))
					__result = true;
			#endregion

			#region Red blood cell replenishment
			if (statusEffectName == "Paralyzed" && __instance.hasStatusEffect("Red blood cell replenishment"))
					__result = true;
			if (statusEffectName == "RegenerateHealth" && __instance.hasStatusEffect("Red blood cell replenishment"))
					__result = true;
			#endregion

			#region The power of Fish Oil
			if (statusEffectName == "Strength" && __instance.hasStatusEffect("The power of Fish Oil"))
					__result = true;
			if (statusEffectName == "Slow" && __instance.hasStatusEffect("The power of Fish Oil"))
					__result = true;
			#endregion

			#region Sticky enrage
			/*if (statusEffectName == "Enraged" && __instance.hasStatusEffect("Sticky enrage"))
					__result = true;*/
			if (statusEffectName == "Slow" && __instance.hasStatusEffect("Sticky enrage"))
					__result = true;
			if (statusEffectName == "AlwaysCrit" && __instance.hasStatusEffect("Sticky enrage"))
					__result = true;
			#endregion

			#region The Tears of Heaven are drunk
			if (statusEffectName == "Invincible" && __instance.hasStatusEffect("The Tears of Heaven are drunk"))
					__result = true;
			if (statusEffectName == "Paralyzed" && __instance.hasStatusEffect("The Tears of Heaven are drunk"))
					__result = true;
			#endregion

			#region Controlled by Brain Jellyfish
			/*if (statusEffectName == "Enraged" && __instance.hasStatusEffect("Controlled by Brain Jellyfish"))
					__result = true;*/
			if (statusEffectName == "ElectroTouch" && __instance.hasStatusEffect("Controlled by Brain Jellyfish"))
					__result = true;
			#endregion

			#region Second heart
			if (statusEffectName == "ResistFire" && __instance.hasStatusEffect("Second heart"))
					__result = true;
			#endregion

			#region Drunk1
			if (statusEffectName == "Slow" && __instance.hasStatusEffect("Drunk1"))
					__result = true;
			if (statusEffectName == "Confused" && __instance.hasStatusEffect("Drunk1"))
					__result = true;
			if (statusEffectName == "Strength" && __instance.hasStatusEffect("Drunk1"))
					__result = true;
			#endregion

			#region Alien ration was eaten
			if (statusEffectName == "IncreaseSpeed" && __instance.hasStatusEffect("Alien ration was eaten"))
					__result = true;
			if (statusEffectName == "IncreaseStrength" && __instance.hasStatusEffect("Alien ration was eaten"))
					__result = true;
			#endregion

			#region Nuclear Barrel was drunk
			if (statusEffectName == "Acid" && __instance.hasStatusEffect("Nuclear Barrel was drunk"))
					__result = true;
			if (statusEffectName == "Slow" && __instance.hasStatusEffect("Nuclear Barrel was drunk"))
					__result = true;
            if (statusEffectName == "Confused" && __instance.hasStatusEffect("Nuclear Barrel was drunk"))
					__result = true;
			if (statusEffectName == "Poisoned" && __instance.hasStatusEffect("Nuclear Barrel was drunk"))
					__result = true;
			#endregion

			#region Nuclear spaghetti was eaten
			if (statusEffectName == "Acid" && __instance.hasStatusEffect("Nuclear spaghetti was eaten"))
					__result = true;
			if (statusEffectName == "Poisoned" && __instance.hasStatusEffect("Nuclear spaghetti was eaten"))
					__result = true;
            #endregion

        }

		public static void StatusEffects_AddStatusEffect(string statusEffectName, int specificTime, StatusEffects __instance)
		{
			if (statusEffectName == "Under KC Drink")
            {
				__instance.agent.SetSpeed(__instance.agent.speedStatMod + 1);
			}
		}

		public static void StatusEffects_RemoveStatusEffect(string statusEffectName, StatusEffects __instance)
        {
			if (!(statusEffectName == "Under KC Drink"))
            {
				__instance.agent.SetSpeed(__instance.agent.speedStatMod - 1);
			}	
		}

		public static void StatusEffects_RemoveTrait(string traitName, bool onlyLocal, StatusEffects __instance)
		{
			try
			{
				if (traitName == "Enraged")
				{
					__instance.agent.enraged = false;
					Debug.LogWarning("1");
					if (__instance.agent.isPlayer > 0)
					{
						__instance.agent.outOfControl = false;
						Debug.LogWarning("2");
						if (!__instance.agent.gc.serverPlayer && __instance.agent.localPlayer)

						{
							__instance.agent.clientOutOfControl = false;
						}
						Debug.LogWarning("3");
						if (__instance.agent.localPlayer)
						{
							__instance.agent.gc?.playerControl?.SetCantPressGameplayButtons("Enraged", 0, __instance.agent.isPlayer - 1);
						}
						Debug.LogWarning("4");
						__instance.agent.pathing = 0;
						__instance.agent.movement.PathStop();
						Debug.LogWarning("5");
						__instance.agent.SetBrainActive(false);
						__instance.agent.brainUpdate.slowAIWait = 0;
						Debug.LogWarning("6");
						if (__instance.agent.gc.serverPlayer)
						{
							if (__instance.agent.brain.Goals.Count > 0)
							{
								__instance.agent.brain.RemoveAllSubgoals(__instance.agent.brain.Goals[0]);
							}
							if (__instance.agent.brain.Goals.Count > 0)
							{
								__instance.agent.brain.Goals[0].Terminate();
							}
							__instance.agent.brain.Goals.Clear();
							Debug.LogWarning("9");
						}
						__instance.agent.mostRecentGoal = "";
						__instance.agent.mostRecentGoalCode = goalType.None;
						Debug.LogWarning("10 ");
						__instance.agent.mostRecentGoalByte = 0;
						Goal goal = new Goal();
						Debug.LogWarning("11 ");
						goal.goalName = "InitialGoal";
						goal.goalCode = goalType.InitialGoal;
						Debug.LogWarning("12 ");
						goal.brain = __instance.agent.brain;
						__instance.agent.brain.Goals.Add(goal);
						Debug.LogWarning("13 ");
						__instance.agent.inCombat = false;
						__instance.agent.inFleeCombat = false;
						Debug.LogWarning("14 ");
					}
					Debug.LogWarning("15 ");
					if (__instance.agent.objectMult.chargingSpecialLunge || __instance.agent.objectMult.chargingSpecialCharge)
					{
						__instance.ReleasedSpecialAbility();

						__instance.agent.combat.specialAttackTime = 0f;
					}
					Debug.LogWarning("16 ");
					for (int num5 = 0; num5 < __instance.agent.gc.agentList.Count; num5++)
					{
						Agent agent5 = __instance.agent.gc.agentList[num5];
						Debug.LogWarning("17 ");
						if (agent5 != __instance)
						{
							Relationship relationship = __instance.agent.relationships.GetRelationship(agent5);
							Relationship relationship2 = agent5.relationships.GetRelationship(__instance.agent);
							if (relationship2.canBeSetBack)

							{
								__instance.agent.relationships.SetRel(agent5, relationship.relBeforeRage);
								__instance.agent.relationships.SetRelHate(agent5, (int)relationship.relHateBeforeRage);
								agent5.relationships.SetRel(__instance.agent, relationship2.relBeforeRageOtherAgent);
							}
						}
						Debug.LogWarning("18 ");
					}
					Debug.LogWarning("19 ");
					if (__instance.agent.isPlayer != 0 && __instance.agent.localPlayer)
					{
						__instance.agent.mainGUI.invInterface.slotsDirty = true;
						Debug.LogWarning("20 ");
						return;

					}
				}

			}
			catch (Exception e)
			{
				Debug.LogError(e);
			}
		}

		public static void StatusEffects_AddTrait(string traitName, bool isStarting, bool justRefresh, StatusEffects __instance)
		{
			if (!(traitName == "Enraged"))
			{
				__instance.agent.enraged = true;
				if (__instance.agent.isPlayer > 0)
				{
					__instance.agent.outOfControl = true;
					if (!__instance.agent.gc.serverPlayer && __instance.agent.localPlayer)
					{
						__instance.agent.clientOutOfControl = true;
					}
					if (__instance.agent.localPlayer)
					{
						bool flag4 = false;
						if (__instance.agent.mainGUI.openedQuestSheet)
						{
							flag4 = true;
							__instance.agent.mainGUI.openedQuestSheet = false;
						}
						__instance.agent.mainGUI.HideEverything();
						if (flag4)
						{
							__instance.agent.mainGUI.openedQuestSheet = true;
						}
						__instance.agent.worldSpaceGUI.HideEverything();
						__instance.agent.mainGUI.invInterface.HideTarget();
						__instance.agent.gc.playerControl.SetCantPressGameplayButtons("Enraged", 1, __instance.agent.isPlayer - 1);
						if (__instance.agent.inventory.equippedWeapon != null && __instance.agent.inventory.equippedWeapon.Categories.Contains("NotRealWeapons"))
						{
							__instance.agent.inventory.UnequipWeapon();
						}
					}
				}
			}
		}

        #endregion
    }
}






