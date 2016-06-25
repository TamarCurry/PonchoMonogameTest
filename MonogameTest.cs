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
			//_agrias.rotation = 45;

			_agrias.x = 70;
			_agrias.y = 70;
			//_agrias.alpha = 0.5f;
			//_agrias.transforms.colorTransform.red = 0.5f;
			_ramza.alpha = 0.5f;

			_ramza.x = 20;
			_ramza.y = 10;
			
			//_agrias.rotation = 30;
			//_agrias.scaleX = -0.5f;
			//_agrias.scaleY = -0.5f;

			TextField t = new TextField();
			t.format = App.GetTextFormat("Tuesday", "Tuesday", 12);
			t.format.color = 0x0000ff;
			//t.rotation = 45;
			t.text = "Tuesday is the best day of the week.";
			//t.clipOverflow = true;
			t.wordWrap = true;
			t.multiline = true;
			t.width = 100;
			t.height = 50;
			//t.clipOverflow = true;
			//t.pivotX = 0.5f;
			//t.pivotY = 0.5f;
			_agrias.AddChild(t);
			_agrias.AddChild(_ramza);


			//App.Subscribe( () => _agrias.rotation += App.deltaTime * 180, true);

			
			App.stage.AddChild(_agrias);
			//App.audio.LoadAndPlayMusic("Destinies", "Destinies");
			//App.stage.AddEventListener(MouseEvent.CLICK, OnMouseEvent);
			//App.stage.AddEventListener(MouseEvent.MOUSE_OVER, OnMouseEvent);
			//App.stage.AddEventListener(MouseEvent.MOUSE_OUT, OnMouseEvent);
			//App.stage.AddEventListener(MouseEvent.MOUSE_WHEEL, OnMouseEvent);
			//_agrias.mouseChildren = false;
			//_agrias.AddChild(_ramza);

			// stress test - render a huge number of sprites to the screen and rotate them every frame.
			Random rand = new Random();
			int num = 100;
			for ( int i = 0; i < num; ++i )
			{
				//AddSprite(rand);
			}
		}
		
		private void AddSprite(Random rand)
		{
			Sprite s = new Sprite();
			s.image = App.images.GetImage("Agrias", new PivotF(0.5f, 0.5f));
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

		private void OnMouseEvent(Event ev)
		{
			MouseEvent e = ev as MouseEvent;
			if(e == null) return;
			Console.WriteLine("Event={0}, relatedObject={1}, delta={2}", e.type, e.relatedObject, e.delta);
		}
	}
}
