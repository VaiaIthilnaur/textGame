using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour 
{

	public Text text;
	private enum States 
	{
		room, room_1, mirror, tork, sheets_0, lock_0, sheets_1, lock_1, corridor_0, corridor_01, corridor_1, corridor_2,
		stairs_0, stairs_1, stairs_2, in_closet, lockpick_0, door, floor, chest, courtyard, in_chest, pick_up, klucz_chest
	};
	private States myState;
	int klucz, kluczchest, lockpick, plaszcz, noz, plecak, ubrania, door_1, tag_0, tag_1, tag_2, grab_lockpick;
	// Use this for initialization
	
	void Start () 
	{
		myState=States.room;
	}
	
	
	#region update
	// Update is called once per frame
	void Update () 
	{
		print(myState); 
		if (myState==States.room)
			{
				room();
			}
		else if (myState==States.sheets_0)
			{
				sheets_0();
			}
		else if (myState==States.room_1)
		{
			room_1();
		}
		else if (myState==States.mirror)
		{
			mirror();
		}
		else if (myState==States.tork)
		{
			tork();
		}
		else if (myState==States.sheets_1)
		{
			sheets_1();
		}
		else if (myState==States.lock_0)
		{
			lock_0();
		}
		else if (myState==States.lock_1)
		{
			lock_1();
		}
		else if (myState==States.corridor_0)
		{
			corridor_0();
		}
		else if (myState==States.corridor_01)
		{
			corridor_01();
		}
		else if (myState==States.corridor_1)
		{
			corridor_1();
		}
		else if (myState==States.stairs_0)
		{
			stairs_0();
		}
		else if (myState==States.stairs_1)
		{
			stairs_1();
		}
		else if (myState==States.stairs_2)
		{
			stairs_2();
		}
		else if (myState==States.door)
		{
			door();
		}
		else if (myState==States.floor)
		{
			floor();
		}
		else if (myState==States.lockpick_0)
		{
			lockpick_0();
		}
		else if (myState==States.in_closet)
		{
			in_closet();
		}
		else if (myState==States.chest)
		{
			chest();
		}
		else if (myState==States.in_chest)
		{
			in_chest();
		}
		else if (myState==States.courtyard)
		{
			courtyard();
		}
		else if (myState==States.pick_up)
		{
			pick_up();
		}
		else if (myState==States.klucz_chest)
		{
			klucz_chest();
		}

	}
	#endregion

	#region State Handle Methods
	void room()
	{
		tag_0=0;
		tag_1=0;
		tag_2=0;
		grab_lockpick=0;
		text.text = 
					"Znajdujesz się w ponurym pokoju oświetlonym jedynie jedną pochodnią wiszącą naprzeciwko Ciebie. "+
					"Prócz niej dostrzegasz swoje łóżko, drewniane, zamknięte na klucz "+
					"drzwi oraz lustro wiszące na ścianie.\n\n"+
					"Naciśnij R aby rozejrzeć się uważniej, L aby podejść do lustra, "+
					"D aby podejść do drzwi, P aby podejść do pochodni";
		if (Input.GetKeyDown(KeyCode.R)) 
		{
			myState=States.sheets_0;
		} 
		else if (Input.GetKeyDown(KeyCode.P)) 
		{
			myState=States.tork;
		} 
		else if (Input.GetKeyDown(KeyCode.D)) 
		{
			myState=States.lock_0;
		} 
		else if (Input.GetKeyDown(KeyCode.L)) 
		{
			myState=States.mirror;
		} 
		else if (Input.GetKeyDown(KeyCode.A)) 
		{
			myState=States.corridor_0;
		} 
	}
	void room_1()
	{
		text.text = 
				"Oświetlając sobię drogę wychodzisz na ciemny korytarz. "+
				"Po drugiej stronie znajdują się kraty lecz czuejsz zimny powiew powietrza - "+
				"to z pewnością wyjście.\n\n"+
				"Naciśnij P aby podejść do krat, Q aby wrócić do pomieszczenia";
		if (Input.GetKeyDown(KeyCode.P)) 
		{
			myState=States.lock_1;
		} 
		else if (Input.GetKeyDown(KeyCode.Q)) 
		{
			myState=States.room;
		} 
	}
	
	void sheets_0()
	{
		text.text = "Brudne, kamienne ściany, "+
					"łóżko złożone tylko z pojednynczego materaca, "+
					"lustro, pochodnia i drzwi... innymi słowy - nic co mogłoby na dłużej zwrócić Twoją uwagę.\n\n"+
					"Kliknij Q aby powrócić";
					
		if (Input.GetKeyDown(KeyCode.Q)) 
		{
			myState=States.room;
		} 
					
	}
	
	void tork()
	{
		text.text = "Ciepły płomień pochodni oświetla Twą twarz. "+
					"Nie pamiętasz zbyt wiele lecz jesteś pewny, iż jesteś tutaj dopiero od kilku dni. "+
					"Pochodnia jest wepchnięta między kammienne bloki...\n\n"+
					"Kliknij Q aby powrócić, Z by zbadać";
		
		if (Input.GetKeyDown(KeyCode.Q)) 
		{
			myState=States.room;
		} 
		else if (Input.GetKeyDown(KeyCode.Z)) 
		{
			myState=States.sheets_1;
		} 
	}
	
	void sheets_1()
	{
		text.text = "Próbujesz wyciągnąć pochodnię. "+
					"Z łatwością to czynisz, i gdy trzymasz ją w ręce w szparze między blokami "+
					"dostrzegasz malutki przedmiot... Z trudem wyciągasz go z małą pomocą zdobytej przed chwilą pochodni - toż to klucz!\n\n"+
					"Kliknij Q aby powrócić";
					klucz=1;
		
		if (Input.GetKeyDown(KeyCode.Q)) 
		{
			myState=States.room;
		} 
		
	}
	
	void mirror()
	{
		text.text = "Stara rama lustra. "+
					"Ciekawi Cię tylko jedna rzecz - gdzie zostały zabrane odłamki szkła?\n\n"+
					"Kliknij Q aby powrócić";
		
		if (Input.GetKeyDown(KeyCode.Q)) 
		{
			myState=States.room;
		} 
		
	}
	
	void lock_0()
	{
		if (klucz==1)
		{
		text.text = "Drewniane drzwi posiadające mały otwór pośrodku. "+
					"Dość nietypowe miejsce na dziurkę od klu... "+
					"Klucz! \n\n"+
					"Kliknij Q aby powrócić, D aby przejść przez drzwi";
					if (Input.GetKeyDown(KeyCode.D)) 
					{
						myState=States.room_1;
					} 
					if (Input.GetKeyDown(KeyCode.Q)) 
					{
						myState=States.room;
					} 
		}
		else 
		{
			text.text = "Drewniane drzwi posiadające mały otwór pośrodku. "+
						"Dość nietypowe miejsce na dziurkę od klucza... "+
						"\n\n"+
						"Kliknij Q aby powrócić";
						if (Input.GetKeyDown(KeyCode.Q)) 
						{
							myState=States.room;
						} 
		}
	}

	void lock_1()
	{
		text.text = "Na ścianie obok krat znajduje się otwór. "+
					"Idealnie nada się on na podtrzymanie pochodni.\n\n "+
					"Kliknij W aby wsadzić pochodnię do otworu, Q aby powrócić";
		
		if (Input.GetKeyDown(KeyCode.Q)) 
		{
			myState=States.room_1;
		} 
		else if (Input.GetKeyDown(KeyCode.W)) 
		{
			myState=States.corridor_0;
		} 
		
	}
	
	void corridor_0()
	{
		text.text = "Kraty otwierają się. Pochodnia uruchomiła jakiś mechanizm otwierający! "+
					"Wychodzisz do kolejnego korytarza. Jest on oświetlony paroma pochodniami oraz świecznikiem "+
					"leżącymi na stole przy ścianie naprzeciw Ciebie. Obok niego leży skrzynia. "+
					"Po lewej stronie znajdują się schody na górę, po prawej zaś drzwi. Na podłodze leży jakiś mały przedmiot...\n\n"+
					"Kliknij C aby podejść do skrzyni, S aby iść na górę, P aby podnieść przedmiot, D aby podejść do drzwi. ";
		
		if (Input.GetKeyDown(KeyCode.C)) 
		{
			myState=States.chest;
		} 
		if (Input.GetKeyDown(KeyCode.S)) 
		{
			myState=States.stairs_0;
		} 
		if (Input.GetKeyDown(KeyCode.P)) 
		{
			myState=States.lockpick_0;
		} 
		if (Input.GetKeyDown(KeyCode.D)) 
		{
			myState=States.door;
		} 
		
	}
	void corridor_01()
	{	if (grab_lockpick==1)
		{
			text.text = "Korytarz. Tym razem jest oświetlony paroma pochodniami oraz świecznikiem "+
						"leżącymi na stole przy przeciwległej ścianie. Obok niego leży skrzynia. "+
						"Po lewej stronie znajdują się schody na górę, po prawej zaś drzwi. Na podłodze leżał lockpick...\n\n"+
						"Kliknij C aby podejść do skrzyni, S aby iść na górę, P aby podejść do miejsca gdzie leżał lockpick, D aby podejść do drzwi. ";
			
			if (Input.GetKeyDown(KeyCode.C)) 
			{
				myState=States.chest;
			} 
			if (Input.GetKeyDown(KeyCode.S)) 
			{
				myState=States.stairs_0;
			} 
			if (Input.GetKeyDown(KeyCode.P)) 
			{
				myState=States.lockpick_0;
			} 
			if (Input.GetKeyDown(KeyCode.D)) 
			{
				myState=States.door;
			}
		}
		else
		{
			text.text = "Korytarz. Tym razem jest oświetlony paroma pochodniami oraz świecznikiem "+
						"leżącymi na stole przy przeciwległej ścianie. Obok niego leży skrzynia. "+
						"Po lewej stronie znajdują się schody na górę, po prawej zaś drzwi. Na podłodze leży jakiś przedmiot...\n\n"+
						"Kliknij C aby podejść do skrzyni, S aby iść na górę, P aby podnieść przedmiot, D aby podejść do drzwi. ";
			
			if (Input.GetKeyDown(KeyCode.C)) 
			{
				myState=States.chest;
			} 
			if (Input.GetKeyDown(KeyCode.S)) 
			{
				myState=States.stairs_0;
			} 
			if (Input.GetKeyDown(KeyCode.P)) 
			{
				myState=States.lockpick_0;
			} 
			if (Input.GetKeyDown(KeyCode.D)) 
			{
				myState=States.door;
			}
		}
	} 
	void chest()
	{	
		if (tag_0==0)
		{
			if (kluczchest==1)
			{
				text.text = "Skrzynia nie jest zbyt duża. Pięknie zdobiona - musi posiadać naprawdę kosztowną zawartość."+
							"Klucz, który znalazłem, powinien pasować do kłódki...\n\n "+
							"Kliknij O aby otworzyć skrzynie, Q aby powrócić";
				if (Input.GetKeyDown(KeyCode.O)) 
				{
					myState=States.in_chest;
				} 
				if (Input.GetKeyDown(KeyCode.S)) 
				{
					myState=States.corridor_01;
				} 
			}
			else 
			{
				text.text = "Skrzynia nie jest zbyt duża. Pięknie zdobiona musi posiadać naprawdę kosztowną zawartość... "+
							"Gdybym tylko miał czym ją otworzyć... Powinienem znaleźć na to jakiś sposób.\n\n "+
							"Kliknij Q aby powrócić";
				if (Input.GetKeyDown(KeyCode.Q)) 
				{
					myState=States.corridor_01;
				} 
			}
		}
		else myState=States.pick_up;
	}
	void in_chest()
	{
		text.text = "Po otwarciu Twym oczom ukazuje się aksamitny, fioletowy plecak. Na plecaku leży nóż do otwierania listów. "+
					"W środku plecaka znajduje się czarny, "+
					"wędrowny płaszcz zapinany złotą zapinką. \n\n "+
					"Kliknij W aby wziąć rzeczy, Q aby powrócić";
		
		if (Input.GetKeyDown(KeyCode.W)) 
		{
			myState=States.pick_up;
		} 
		else if (Input.GetKeyDown(KeyCode.Q)) 
		{
			myState=States.corridor_01;
		} 
		
	}
	void pick_up()
	{
		if (tag_0==0)
		{
			text.text = "Do twojego inwentarza dodano następujące przedmioty: \n"+
						"Płaszcz wędrowny +1\n "+
						"Nóż do listów +1\n "+
						"Plecak +1 --> od teraz możesz nosić więcej przedmiotów!\n\n "+
						"Kliknij Q aby powrócić";
			
			plaszcz=1;
			noz=1;
			plecak=1;
						
			if (Input.GetKeyDown(KeyCode.Q)) 
			{
				tag_0=1;
				myState=States.corridor_01;
			} 
		}
		else
		{
			text.text = "Podniosłeś wcześniej następujące przedmioty: \n"+
						">Płaszcz wędrowny +1\n "+
						">Nóż do listów +1\n "+
						">Plecak +1 \n\n "+
						"Kliknij Q aby powrócić";
			
			if (Input.GetKeyDown(KeyCode.Q)) 
			{
				myState=States.corridor_01;
			} 
		}
		
	}
	void lockpick_0()
	{
		if (tag_1==0)
		{
			text.text = "Przedmiot, który zwrócił Twoją uwagę to lockpick!"+
						"\n\n "+
						"Kliknij Q aby powrócić";
			lockpick=1;
			
			if (Input.GetKeyDown(KeyCode.Q)) 
			{
				grab_lockpick=1;
				tag_1=1;
				myState=States.corridor_01;
			} 
		}
		else
		{
			text.text = "Nic już tu nie ma..."+
						"\n\n "+
						"Kliknij Q aby powrócić";
			if (Input.GetKeyDown(KeyCode.Q)) 
			{
				myState=States.corridor_01;
			} 
		}
	
	}
	void stairs_0()
	{
		if (ubrania==0)
		{
			text.text = "Na górze znajdują się drzwi. Nad nimi duży napis 'Dziedziniec'. "+
						"Jednak bez odpowiednich ubrań, nie powinienem raczej tam wychodzić..."+
						"\n\n "+
						"Kliknij Q aby powrócić";
			if (Input.GetKeyDown(KeyCode.Q)) 
			{
				myState=States.corridor_01;
			} 
	}	
		else 
		{		
					text.text = "Na górze znajdują się drzwi. Nad nimi duży napis 'Dziedziniec'. "+
								"Teraz mogę wyruszyć!"+
								"\n\n "+
								"Kliknij Q aby powrócić, W aby wyruszyć na dziedziniec";
		if (Input.GetKeyDown(KeyCode.Q)) 
			{
				myState=States.corridor_01;
			} 
		if (Input.GetKeyDown(KeyCode.W)) 
			{
				myState=States.courtyard;
			} 
		}
	}
	void door()
	{
		if (lockpick==1)
		{
			text.text = "Zamknięte drzwi... Mogę je otworzyć lockpickiem! "+
						"Udało Ci się otworzyć zamek lecz lockpick został zniszczony.\n\n "+
						"Kliknij Q aby powrócić, D aby iść dalej";
		if (Input.GetKeyDown(KeyCode.Q)) 
			{
				lockpick=0;
				myState=States.corridor_01;
			} 
		if (Input.GetKeyDown(KeyCode.D)) 
			{
				lockpick=0;
				myState=States.floor;
			} 
		}
		else if (door_1==1)
		{
			text.text = "Drzwi - już je otworzyłem."+
						"\n\n "+
						"Kliknij Q aby powrócić, D aby iść dalej";
			if (Input.GetKeyDown(KeyCode.Q)) 
			{
				myState=States.corridor_01;
			} 
			if (Input.GetKeyDown(KeyCode.D)) 
			{
				myState=States.floor;
			} 
		}
		
		else if (door_1==0)
		{
			text.text = "Zamknięte drzwi... Potrzebuję czegość do otwarcia tych wrót..."+
						"\n\n "+
						"Kliknij Q aby powrócić";
			if (Input.GetKeyDown(KeyCode.Q)) 
			{
				myState=States.corridor_01;
			} 
		}
		else if (lockpick==0)
		{
			text.text = "Zamknięte drzwi... Potrzebuję czegość do otwarcia tych wrót..."+
						"\n\n "+
						"Kliknij Q aby powrócić";
			if (Input.GetKeyDown(KeyCode.Q)) 
			{
				myState=States.corridor_01;
			} 
		}
		
	}
	void floor()
	{	
		door_1=1;
		lockpick=0;
		text.text = "Pomieszczenie w którym się znalazłeś to następny korytarz. Na dodatek - wygląda dokładnie tak samo jak poprzedni... "+
					"Z tą jednak różnicą, że na stole leży tylko klucz oraz jakaś zapinka do włosów a drzwi po prawej są otwarte.\n\n"+
					"Kliknij S aby iść na górę, K aby podejść do stołu, D aby przejść przez drzwi, Q aby powrócić do korytarza";

		if (Input.GetKeyDown(KeyCode.S)) 
		{
			myState=States.stairs_1;
		} 
		if (Input.GetKeyDown(KeyCode.K)) 
		{
			myState=States.klucz_chest;
		} 
		if (Input.GetKeyDown(KeyCode.D)) 
		{
			myState=States.corridor_1;
		} 
		if (Input.GetKeyDown(KeyCode.Q)) 
		{
			myState=States.corridor_01;
		} 

		
	}
	void klucz_chest()
	{	
			if (tag_2==0)
			{
				text.text = "Przedmioty, które zebrałeś:\n"+
							"Klucz +1 \n"+
							"Zapinka do włosów +1 \n\n "+
							"Kliknij Q aby powrócić";
				kluczchest=1;
				
				if (Input.GetKeyDown(KeyCode.Q)) 
				{
					tag_2=1;
					myState=States.floor;
				} 
			}
			else
			{
				text.text = "Wcześniej zebrałeś następujące przedmioty:\n"+
							"Klucz +1 \n"+
							"Zapinka do włosów +1 \n\n "+
							"Kliknij Q aby powrócić";
				if (Input.GetKeyDown(KeyCode.Q)) 
				{
					myState=States.floor;
				} 
			}
	}
	void stairs_1()
	{
		if (ubrania==0)
		{
			text.text = "Na górze znajdują się drzwi. Nad nimi duży napis 'Dziedziniec'. "+
						"Jednak bez odpowiednich ubrań, nie powinienem raczej tam wychodzić..."+
						"\n\n "+
						"Kliknij Q aby powrócić";
			if (Input.GetKeyDown(KeyCode.Q)) 
			{
				myState=States.floor;
			} 
		}	
		else 
		{		
			text.text = "Na górze znajdują się drzwi. Nad nimi duży napis 'Dziedziniec'. "+
						"Teraz mogę wyruszyć!"+
						"\n\n "+
						"Kliknij Q aby powrócić, W aby wyruszyć na dziedziniec";
			if (Input.GetKeyDown(KeyCode.Q)) 
			{
				myState=States.floor;
			} 
			if (Input.GetKeyDown(KeyCode.W)) 
			{
				myState=States.courtyard;
			}
		}
	}
	void corridor_1()
	{
		text.text = "Znów korytarz. Tym razem znajduje się tu tylko szafa naprzeciwko Ciebie. "+
					"Po twojej lewej kolejne schody...\n\n"+
					"Kliknij C aby podejść do szafy, S aby iść na górę, Q aby powrócić ";
		
		if (Input.GetKeyDown(KeyCode.C)) 
		{
			myState=States.in_closet;
		} 
		if (Input.GetKeyDown(KeyCode.S)) 
		{
			myState=States.stairs_2;
		} 
		if (Input.GetKeyDown(KeyCode.Q)) 
		{
			myState=States.floor;
		} 
	}
	void stairs_2()
	{
		if (ubrania==0)
		{
			text.text = "Na górze znajdują się drzwi. Nad nimi duży napis 'Dziedziniec'. "+
						"Jednak bez odpowiednich ubrań, nie powinienem raczej tam wychodzić..."+
						"\n\n "+
						"Kliknij Q aby powrócić";
			if (Input.GetKeyDown(KeyCode.Q)) 
			{
				myState=States.corridor_1;
			} 
		}	
		else 
		{		
			text.text = "Na górze znajdują się drzwi. Nad nimi duży napis 'Dziedziniec'. "+
						"Teraz mogę wyruszyć!"+
						"\n\n "+
						"Kliknij Q aby powrócić, W aby wyruszyć na dziedziniec";
			if (Input.GetKeyDown(KeyCode.Q)) 
			{
				myState=States.corridor_1;
			} 
			if (Input.GetKeyDown(KeyCode.W)) 
			{
				myState=States.courtyard;
			}
		}
	}
	void in_closet()
	{
		text.text = "W szafie znajdujesz parę ciuchów. Na ulicy nikt nie powinien się domyśleć skąd uciekłeś... "+
					"\n\n "+
					"Kliknij Q aby powrócić";
		ubrania=1;
		if (Input.GetKeyDown(KeyCode.Q)) 
		{
			myState=States.corridor_1;
		} 
			
	}
	
		void courtyard()
		{
			text.text = "Wychodzisz na ulice... W końcu wolny :P "+
						"\n\n "+
						"Kliknij Q aby włączyć grę od początku!";
			if (Input.GetKeyDown(KeyCode.Q)) 
			{
				myState=States.room;
				klucz=0;
				kluczchest=0;
				lockpick=0;
				plaszcz=0;
				noz=0;
				plecak=0;
				ubrania=0;
				door_1=0;
				tag_0=0;
				tag_1=0;
				tag_2=0;
				grab_lockpick=0;
			} 
		}
	
	#endregion
}