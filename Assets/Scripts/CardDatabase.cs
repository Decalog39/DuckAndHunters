using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public List<Card> cardList = new List<Card>();

    void Awake()
    {
        /*
        cardList.Add(new Card(0, true, "Duckling", 1, 1, 1, "This is a Duckling",Resources.Load<Sprite>("Ducks/duckling")));
        cardList.Add(new Card(1, true, "Duckling", 1, 1, 1, "This is a Duckling",Resources.Load<Sprite>("Ducks/duckling")));
        cardList.Add(new Card(2, true, "Duckling", 1, 1, 1, "This is a Duckling",Resources.Load<Sprite>("Ducks/duckling")));
        cardList.Add(new Card(3, true, "Duckling", 1, 1, 1, "This is a Duckling",Resources.Load<Sprite>("Ducks/duckling")));
        cardList.Add(new Card(4, true, "Mallard", 2, 2, 3, "Just a regular wild duck",Resources.Load<Sprite>("Ducks/mallard"))); 
        cardList.Add(new Card(5, true, "Mallard", 2, 2, 3, "Just a regular wild duck",Resources.Load<Sprite>("Ducks/mallard"))); 
        cardList.Add(new Card(6, true, "Mallard", 2, 2, 3, "Just a regular wild duck",Resources.Load<Sprite>("Ducks/mallard"))); 
        cardList.Add(new Card(7, true, "Duck", 2, 3, 2, "Just a regular household duck",Resources.Load<Sprite>("Ducks/household_duck"))); 
        cardList.Add(new Card(8, true, "Duck", 2, 3, 2, "Just a regular household duck",Resources.Load<Sprite>("Ducks/household_duck"))); 
        cardList.Add(new Card(9, true, "Duck", 2, 3, 2, "Just a regular household duck",Resources.Load<Sprite>("Ducks/household_duck"))); 
        
        cardList.Add(new Card(10, true,"King Duck", 8, 10, 7, "Buffs all ducks and mallards on field by +1 attack.",Resources.Load<Sprite>("Ducks/duck_king")));
        cardList.Add(new Card(11, true,"Crown Princess Duck", 6, 6, 7, "Random buff to random card on your field)",Resources.Load<Sprite>("Ducks/queen_duck")));

        cardList.Add(new Card(12,true, "Soldier Duck", 4, 5, 4, "Adds +1 health to all regular ducks already on board.",Resources.Load<Sprite>("Ducks/soldier_duck")));
        cardList.Add(new Card(13,true, "Soldier Duck", 4, 5, 4, "Adds +1 health to all regular ducks already on board.",Resources.Load<Sprite>("Ducks/soldier_duck")));
        cardList.Add(new Card(14,true, "Soldier Duck", 4, 5, 4, "Adds +1 health to all regular ducks already on board.",Resources.Load<Sprite>("Ducks/soldier_duck")));

        cardList.Add(new Card(15, true, "D**k", 5, 3, 6, "This is a D**k. It packs a punch.",Resources.Load<Sprite>("Ducks/d-k"))); //higher stats

        cardList.Add(new Card(16, true, "Flock", 5, 7, 5, "For each duck you control, add that much health to target card.",Resources.Load<Sprite>("Ducks/flock")));
        cardList.Add(new Card(17, true, "Flock", 5, 7, 5, "For each duck you control, add that much health to target card",Resources.Load<Sprite>("Ducks/flock")));

        cardList.Add(new Card(18, true, "Brace", 4, 4, 4, "When Brace dies, spawn Duck partner",Resources.Load<Sprite>("Ducks/brace"))); //two ducks
        cardList.Add(new Card(19, true, "Brace", 4, 4, 4, "When Brace dies, spawn Duck partner",Resources.Load<Sprite>("Ducks/brace"))); //two ducks

        cardList.Add(new Card(20, true, "Donovan Duck", 4, 5, 5, "If Donovan defends and lives, he doesn't lose health",Resources.Load<Sprite>("Ducks/donovan_duck")));
        cardList.Add(new Card(21, true, "Donovan Duck", 4, 5, 5, "If Donovan defends and lives, he doesn't lose health",Resources.Load<Sprite>("Ducks/donovan_duck")));

        cardList.Add(new Card(22, false, "Waddle", 1, 0, 0, "Draw a card",Resources.Load<Sprite>("Ducks/waddle"))); 
        cardList.Add(new Card(23, false, "Rest", 2, 0, 0, "Target card gets +2 health",Resources.Load<Sprite>("Ducks/rest"))); 
        cardList.Add(new Card(24, false, "Rest", 2, 0, 0, "Target card gets +2 health",Resources.Load<Sprite>("Ducks/rest"))); 
        cardList.Add(new Card(25, false, "Fence", 4, 0, 0, "Enemy player's health is decreased by 2.",Resources.Load<Sprite>("Ducks/fence")));
        cardList.Add(new Card(26, false, "Drown", 8, 0, 0, "Kill target character",Resources.Load<Sprite>("Ducks/drown"))); 
        cardList.Add(new Card(27, false, "Bread", 5, 0, 0, "Health + 1 for all cards on your field", Resources.Load<Sprite>("Ducks/bread")));
        cardList.Add(new Card(28, false, "Sleep with one eye open", 9, 0, 0, "Adds 10 health to target card",Resources.Load<Sprite>("Ducks/sleep_with_one_eye_open")));
        cardList.Add(new Card(29, false, "QUACK", 4, 0, 0, "Randomly inc./ dec. target card's attack and health by between 0 and 5",Resources.Load<Sprite>("Ducks/quack")));
        
        // hunters
        cardList.Add(new Card(30, true, "Apprentice Hunter", 1, 1, 1, "This is an Apprentice.",Resources.Load<Sprite>("bread_test")));
        cardList.Add(new Card(31, true, "Apprentice Hunter", 1, 1, 1, "This is an Apprentice.",Resources.Load<Sprite>("bread_test")));
        cardList.Add(new Card(32, true, "Apprentice Hunter", 1, 1, 1, "This is an Apprentice.",Resources.Load<Sprite>("bread_test")));
        cardList.Add(new Card(33, true, "Apprentice Hunter", 1, 1, 1, "This is an Apprentice.",Resources.Load<Sprite>("bread_test")));
        cardList.Add(new Card(34, true, "Hunter", 2, 2, 3, "This is a regular hunter.",Resources.Load<Sprite>("Hunters/hunter"))); 
        cardList.Add(new Card(35, true, "Hunter", 2, 2, 3, "This is a regular hunter.",Resources.Load<Sprite>("Hunters/hunter"))); 
        cardList.Add(new Card(36, true, "Hunter", 2, 2, 3, "This is a regular hunter.",Resources.Load<Sprite>("Hunters/hunter"))); 
        cardList.Add(new Card(37, true, "Archer", 2, 3, 2, "This is a regular Archer.",Resources.Load<Sprite>("bread_test")));
        cardList.Add(new Card(38, true, "Archer", 2, 3, 2, "This is a regular Archer.",Resources.Load<Sprite>("bread_test")));
        cardList.Add(new Card(39, true, "Archer", 2, 3, 2, "This is a regular Archer.",Resources.Load<Sprite>("bread_test")));

        cardList.Add(new Card(40, true, "Master Hunter", 8, 12, 11, "This is a Master Hunter. Super strong",Resources.Load<Sprite>("bread_test"))); //no special effects
        cardList.Add(new Card(41, true, "Artemis", 8, 3, 4, "Adds +1 attack and +1 health for each card on your field",Resources.Load<Sprite>("bread_test")));


        cardList.Add(new Card(42, true, "Beagle", 4, 5, 4, "Adds +1 attack to all the regular hunters already on board.",Resources.Load<Sprite>("bread_test"))); 
        cardList.Add(new Card(43, true, "Beagle", 4, 5, 4, "Adds +1 attack to all the regular hunters already on board.",Resources.Load<Sprite>("bread_test"))); 
        cardList.Add(new Card(44, true, "Beagle", 4, 5, 4, "Adds +1 attack to all the regular hunters already on board.",Resources.Load<Sprite>("bread_test"))); 

        cardList.Add(new Card(45, true, "Recreational Hunter", 0, 3, 6, "Sacrifice 3 player health to play this card",Resources.Load<Sprite>("bread_test")));

        cardList.Add(new Card(46, true, "Duck Tolling Retriever", 5, 7, 5, "For each enemy duck, add that much attack to target card.",Resources.Load<Sprite>("bread_test")));
        cardList.Add(new Card(47, true, "Duck Tolling Retriever", 5, 7, 5, "For each enemy duck, add that much attack to target card.",Resources.Load<Sprite>("bread_test")));

        cardList.Add(new Card(48, true, "Trap Setter", 4, 5, 4, "Removes 2 health from target card.",Resources.Load<Sprite>("bread_test"))); 
        cardList.Add(new Card(49, true, "Trap Setter", 4, 5, 4, "Removes 2 health from target card.",Resources.Load<Sprite>("bread_test"))); 
            
        cardList.Add(new Card(50, true, "Assassin", 4, 5, 5, "If it kills a card during attack, the damage enemy player takes is doubled.",Resources.Load<Sprite>("bread_test")));
        cardList.Add(new Card(51, true, "Assassin", 4, 5, 5, "If it kills a card during attack, the damage enemy player takes is doubled.",Resources.Load<Sprite>("bread_test")));

        cardList.Add(new Card(52, false, "Expedition", 1, 0, 0, "Draw a card",Resources.Load<Sprite>("bread_test")));
        cardList.Add(new Card(53, false, "Hunting season", 2, 0, 0, "Target card gets +2 attack",Resources.Load<Sprite>("bread_test"))); 
        cardList.Add(new Card(54, false, "Hunting season", 2, 0, 0, "Target card gets +2 attack",Resources.Load<Sprite>("bread_test"))); 
        cardList.Add(new Card(55, false, "Trap", 4, 0, 0, "Halves the health and attack of target card (round down if odd)",Resources.Load<Sprite>("bread_test")));
        cardList.Add(new Card(56, false, "Camouflage", 8, 0, 0, "You take no damage until your next turn",Resources.Load<Sprite>("bread_test")));
        cardList.Add(new Card(57, false, "Motivation", 5, 0, 0, "Attack +1 for all cards on your field",Resources.Load<Sprite>("bread_test")));
        cardList.Add(new Card(58, false, "Gunpowder", 6, 0, 0, "Adds 5 attack to target card",Resources.Load<Sprite>("Hunters/gunpowder")));
        cardList.Add(new Card(59, false, "Swap", 4, 0, 0, "Swap the health and attack stats of target card",Resources.Load<Sprite>("bread_test")));


        // duck tokens
        cardList.Add(new Card(60, true, "Partner Duck", 2, 3, 2, "Just a regular household duck",Resources.Load<Sprite>("Ducks/household_duck"))); 
        cardList.Add(new Card(61, true, "Partner Duck", 2, 3, 2, "Just a regular household duck",Resources.Load<Sprite>("Ducks/household_duck"))); */

    }
}