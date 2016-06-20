﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poncho;
using Poncho.Geom;
using Poncho.Framework;
using Poncho.Display;

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

			_agrias.image = App.GetImage("Agrias", new Pivot(0.5f, 0.5f));
			_ramza.image = App.GetImage("Ramza");

			//_ramza.rotation = 45;
			//_agrias.rotation = 90;

			_agrias.x = 400;
			_agrias.y = 400;
			
			_agrias.rotation = 30;
			_agrias.scaleX = -0.5f;
			_agrias.scaleY = -0.5f;

			//App.Subscribe( () => _agrias.rotation += App.deltaTime * 180, true);

			App.stage.AddChild(_agrias);
			//_agrias.AddChild(_ramza);

			// stress test - render a huge number of sprites to the screen and rotate them every frame.
			/*Random rand = new Random();
			int num = 1000;
			for ( int i = 0; i < num; ++i )
			{
				AddSprite(rand);
			}*/
		}

		private void AddSprite(Random rand)
		{
			Sprite s = new Sprite();
			s.image = App.GetImage("Agrias", new Pivot(135, 244));
			float scale = 0.5f + ( rand.Next(0, 6) * 0.1f );
			s.scaleX = s.scaleY = scale;
			s.x = rand.Next(10, 1070);
			s.y = rand.Next(10, 710);
			s.rotation = rand.Next(0, 360);
			int rotSpeed = rand.Next(1, 360);
			App.stage.AddChild(s);
			UpdateDelegate updateSprite = () => { s.rotation += App.deltaTime * rotSpeed; };
			App.Subscribe(updateSprite, true);
		}
	}
}
