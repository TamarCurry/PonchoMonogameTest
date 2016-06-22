using System;
using Poncho;
using Poncho.Geom;
using Poncho.Framework;
using Poncho.Display;
using Poncho.Events;
using Poncho.Text;

namespace PonchoMonogameTest
{
	public class MonogameTest
	{
		private Sprite _agrias;
		private Sprite _ramza;

		public MonogameTest()
		{
			_agrias = new Sprite();
			_ramza = new Sprite();

			_agrias.image = App.images.GetImage("Agrias");
			_ramza.image = App.images.GetImage("Ramza");

			_agrias.name = "Agrias";
			//_ramza.rotation = 45;
			//_agrias.rotation = 90;

			_agrias.x = 100;
			_agrias.y = 100;
			
			//_agrias.rotation = 30;
			//_agrias.scaleX = -0.5f;
			//_agrias.scaleY = -0.5f;

			TextField t = new TextField();
			t.format = App.GetTextFormat("Tuesday", "Tuesday", 12);
			t.text = "Tuesday";
			t.pivotX = 0.5f;
			t.pivotY = 0.5f;
			_agrias.AddChild(t);


			//App.Subscribe( () => _agrias.rotation += App.deltaTime * 180, true);

			
			App.stage.AddChild(_agrias);
			//App.audio.LoadAndPlayMusic("Destinies", "Destinies");
			_agrias.AddEventListener(MouseEvent.CLICK, OnMouseEvent);
			_agrias.AddEventListener(MouseEvent.MOUSE_OVER, OnMouseEvent);
			_agrias.AddEventListener(MouseEvent.MOUSE_OUT, OnMouseEvent);
			_agrias.AddEventListener(MouseEvent.MOUSE_WHEEL, OnMouseEvent);
			//_agrias.AddChild(_ramza);

			// stress test - render a huge number of sprites to the screen and rotate them every frame.
			/*Random rand = new Random();
			int num = 100;
			for ( int i = 0; i < num; ++i )
			{
				AddSprite(rand);
			}*/
		}
		
		private void AddSprite(Random rand)
		{
			Sprite s = new Sprite();
			s.image = App.images.GetImage("Agrias", new Pivot(0.5f, 0.5f));
			float scale = 0.5f + ( rand.Next(0, 6) * 0.1f );
			s.scaleX = s.scaleY = scale;
			s.x = rand.Next(10, 1070);
			s.y = rand.Next(10, 710);
			s.rotation = rand.Next(0, 360);
			//int rotSpeed = rand.Next(1, 360);
			App.stage.AddChild(s);
			UpdateDelegate updateSprite = () => { s.rotation += App.deltaTime * 180; };
			App.Subscribe(updateSprite, true);
		}

		private void OnMouseEvent()
		{
			MouseEvent e = Event.activeEvent as MouseEvent;
			if(e == null) return;
			Console.WriteLine("Event={0}, relatedObject={1}, delta={2}", e.type, e.relatedObject, e.delta);
		}
	}
}
