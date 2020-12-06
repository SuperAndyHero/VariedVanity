using System.IO;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;
using System.Collections.Generic;
using Terraria.GameContent.Generation;
using Terraria.World.Generation;
using System;

namespace VariedVanity
{
    class VanityWorld : ModWorld
	{
		public static int neonTiles = 0;
		public bool ShowBlocks = false;
		public static float TorchTimerSin = 0f;
        public bool DoubleToggle1 = false;//remove
        public bool DoubleToggle2 = false;//remove


        public override void ResetNearbyTileEffects()
		{
			VisualPlayer modPlayer = Main.LocalPlayer.GetModPlayer<VisualPlayer>();
			modPlayer.FountainNeon = false;
			neonTiles = 0;
        }

		public override void TileCountsAvailable(int[] tileCounts)
		{
			neonTiles += tileCounts[mod.TileType("NeonRed")];
			neonTiles += tileCounts[mod.TileType("NeonOrange")];
			neonTiles += tileCounts[mod.TileType("NeonYellow")];
			neonTiles += tileCounts[mod.TileType("NeonGreen")];
			neonTiles += tileCounts[mod.TileType("NeonTeal")];
			neonTiles += tileCounts[mod.TileType("NeonLightBlue")];
			neonTiles += tileCounts[mod.TileType("NeonBlue")];
			neonTiles += tileCounts[mod.TileType("NeonPurple")];
			neonTiles += tileCounts[mod.TileType("NeonPink")];

		}

        public override void NetSend(BinaryWriter writer)//todo: only sync this when needed, and every so often and have clients keep track
        {
            writer.Write(TorchTimerSin);
        }

        public override void NetReceive(BinaryReader reader)
        {
            TorchTimerSin = reader.ReadSingle();
        }






        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            int FinalIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Final Cleanup"));

            if (ShiniesIndex != -1)
            {
                tasks.Insert(FinalIndex + 1, new PassLegacy("Gird-i-fy", GraphRed));
                tasks.Insert(FinalIndex + 2, new PassLegacy("Gird-i-fy", GraphGreen));
                tasks.Insert(FinalIndex + 3, new PassLegacy("Gird-i-fy 2", AntiRed));
                tasks.Insert(FinalIndex + 4, new PassLegacy("Gird-i-fy 2", AntiGreen));
            }
        }

        private void GraphRed(GenerationProgress progress)
        {
            progress.Message = "Begone Blocks";

            for (int j = 0; j < Main.maxTilesY; j++)
            {
                for (float k = 0; k < (int)Main.maxTilesX; k = k + 0.1f)
                {
					if (j % 30 == 0) //spacing //(j % 30 == 0) //(j == Main.maxTilesY / 2)
                    {
                        for(int g = 0; g < 5; g++) //number = line width
                        {
                            WorldGen.PlaceTile((int)k, j + (int)(Math.Sin(k / 10) * 13) + g, TileID.RubyGemspark, true, true); //(k / frequency {higher number is lower} ) * aplitude //j + (int)((Math.Sin(k / 10) + Math.Sin(k / 20)) * 13) + g
                            //WorldGen.KillTile((int)k, j + (int)(Math.Sin(k / 10) * 10) + g, false, false, true);
                        }
					}
				
				}
            }
        }

        //copy
        private void GraphGreen(GenerationProgress progress)
        {
            progress.Message = "Begone Blocks";

            for (int j = 0; j < Main.maxTilesY; j++)
            {
                for (float k = 0; k < (int)Main.maxTilesX; k = k + 0.1f)
                {
                    if (j % 30 == 0) //spacing //(j % 30 == 0) //(j == Main.maxTilesY / 2)
                    {
                        for (int g = 0; g < 5; g++) //number = line width
                        {
                            WorldGen.PlaceTile((int)k, j + (int)(Math.Cos(k / 10) * 13) + g, TileID.EmeraldGemspark, true, true); //(k / frequency {higher number is lower} ) * aplitude //j + (int)((Math.Sin(k / 10) + Math.Sin(k / 20)) * 13) + g
                            //WorldGen.KillTile((int)k, j + (int)(Math.Sin(k / 10) * 10) + g, false, false, true);
                        }
                    }

                }
            }
        }

        private void AntiRed(GenerationProgress progress)
        {
            progress.Message = "Begone Blocks (AA)";

            for (int k = 3; k < Main.maxTilesX - 3; k++)
            {
                for (int j = 3; j < Main.maxTilesY - 3; j++)
                {
                    if (Main.tile[k, j].type != TileID.RubyGemspark)
                    {
                        int gemCount = 0;
                        for(int g = -1; g < 2; g++)
                        {
                            for (int h = -1; h < 2; h++)
                            {
                                if (Main.tile[k + g, j + h].type == TileID.RubyGemspark)
                                {
                                    gemCount++;
                                }
                            }
                        }
                        if (gemCount >= 4) //lowering number increases AA
                        {
                            WorldGen.PlaceTile(k, j, TileID.RubyGemsparkOff, true, true);
                        }
                    }
                }
            }
        }

        //Copy
        private void AntiGreen(GenerationProgress progress)
        {
            progress.Message = "Begone Blocks (AA)";

            for (int k = 3; k < Main.maxTilesX - 3; k++)
            {
                for (int j = 3; j < Main.maxTilesY - 3; j++)
                {
                    if (Main.tile[k, j].type != TileID.EmeraldGemspark)
                    {
                        int gemCount = 0;
                        for (int g = -1; g < 2; g++)
                        {
                            for (int h = -1; h < 2; h++)
                            {
                                if (Main.tile[k + g, j + h].type == TileID.EmeraldGemspark)
                                {
                                    gemCount++;
                                }
                            }
                        }
                        if (gemCount >= 4) //lowering number increases AA
                        {
                            WorldGen.PlaceTile(k, j, TileID.EmeraldGemsparkOff, true, true);
                        }
                    }
                }
            }
        }









        public bool VerletChain = true;
        public bool init = false;

        public List<RopeSegment> ropeSegments = new List<RopeSegment>();
        public float ropeSegLen = 5f;
        public int segmentLength = 80;

        //public float time = 1f;
        //public float lineWidth = 0.1f;

        void Start()
        {
            Vector2 ropeStartPoint = Main.MouseWorld;

            for (int i = 0; i < segmentLength; i++)
            {
                this.ropeSegments.Add(new RopeSegment(ropeStartPoint));
                ropeStartPoint.Y -= ropeSegLen;
            }
        }


        public override void PreUpdate()
        {
			TorchTimerSin = (float)Math.Sin((float)Main.GameUpdateCount * 0.01);//seperate
			
            if (VerletChain)
            {
                if(init == false)
                {
                    this.Start(); //run once
                    init = true;
                }

                this.DrawRope();
                this.Simulate();



            }
            else if(!VerletChain && init == true)
            {
                //Reset
            }
        }

        private void Simulate()
        {
            // SIMULATION
            Vector2 forceGravity = new Vector2(0f, 1f); //GRAVITY

            for (int i = 1; i < this.segmentLength; i++)
            {
                RopeSegment firstSegment = this.ropeSegments[i];
                Vector2 velocity = firstSegment.posNow - firstSegment.posOld;
                firstSegment.posOld = firstSegment.posNow;
                firstSegment.posNow += velocity;
                firstSegment.posNow += forceGravity; //firstSegment.posNow += forceGravity * time;
                this.ropeSegments[i] = firstSegment;

            }

            //CONSTRAINTS
            for (int i = 0; i < 50; i++)
            {
                this.ApplyConstraint();
            }
        }

        private void ApplyConstraint()
        {
            //Constrant to Mouse
            RopeSegment firstSegment = this.ropeSegments[0];
            firstSegment.posNow = Main.MouseWorld;
            this.ropeSegments[0] = firstSegment;

            for (int i = 0; i < this.segmentLength - 1; i++)
            {
                RopeSegment firstSeg = this.ropeSegments[i];
                RopeSegment secondSeg = this.ropeSegments[i + 1];

                //Vector2 distVect = (firstSeg.posNow - secondSeg.posNow);
                //float dist = (float)Math.Sqrt(distVect.X * (distVect.X + distVect.Y) * distVect.Y);

                float dist = (firstSeg.posNow - secondSeg.posNow).Length();
                float error = Math.Abs(dist - this.ropeSegLen);
                Vector2 changeDir = Vector2.Zero;

                if (dist > ropeSegLen)
                {
                    changeDir = Vector2.Normalize(firstSeg.posNow - secondSeg.posNow);
                }
                else if (dist < ropeSegLen)
                {
                    changeDir = Vector2.Normalize(secondSeg.posNow - firstSeg.posNow);
                }

                Vector2 changeAmount = changeDir * error;
                if (i != 0)
                {
                    firstSeg.posNow -= changeAmount * 0.5f;
                    this.ropeSegments[i] = firstSeg;
                    secondSeg.posNow += changeAmount * 0.5f;
                    this.ropeSegments[i + 1] = secondSeg;
                }
                else
                {
                    secondSeg.posNow += changeAmount;
                    this.ropeSegments[i + 1] = secondSeg;
                }
            }
        }

        private void DrawRope()
        {
            Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
            Vector2[] ropePositions = new Vector2[this.segmentLength];

            for (int i = 0; i < this.segmentLength; i++)
            {
                ropePositions[i] = this.ropeSegments[i].posNow;

                //if (Main.rand.NextBool(3))
                Dust.NewDust(ropePositions[i], 1, 1, 43); //PARTICLE
            }
        }

        public struct RopeSegment
        {
            public Vector2 posNow;
            public Vector2 posOld;

            public RopeSegment(Vector2 pos)
            {
                this.posNow = pos;
                this.posOld = pos;
            }
        }







        /*public override void PreUpdate()
		{
            TorchTimerSin = (float)Math.Sin((float)Main.GameUpdateCount * 0.01);
            //Main.NewText(TorchTimerSin);

            int gravelType1 = mod.TileEntityType<Tiles.GravelEntity>();

            //if (Main.netMode == 0)
            //{
                //1/4 the speed
                if (DoubleToggle1)//hacky gravel that works but corrupts worlds with TEs
                {
                    if (DoubleToggle2)
                    {

                        foreach (var item in TileEntity.ByID.ToList())
                        {
                            if (item.Value.type == gravelType1)
                            {
                                var gravel1 = item.Value as Tiles.GravelEntity;
                                Vector2 entityPos = gravel1.TileEntPos();



                                //Checks if within world bounds
                                if (entityPos.X > 10 && entityPos.X < Main.maxTilesX - 10 && entityPos.Y > 10 && entityPos.Y < Main.maxTilesY - 10)
                                {
                                    //Down
                                    if (WorldGen.EmptyTileCheck((int)entityPos.X, (int)entityPos.X, (int)entityPos.Y + 1, (int)entityPos.Y + 1))
                                    {
                                        if (Main.tile[(int)entityPos.X, (int)entityPos.Y].type == mod.TileType<Tiles.Gravel>())
                                        {//Gravel
                                            WorldGen.PlaceTile((int)entityPos.X, (int)entityPos.Y + 1, mod.TileType<Tiles.Gravel>(), true, true);
                                            WorldGen.SquareTileFrame((int)entityPos.X, (int)entityPos.Y, true);
                                            NetMessage.SendTileSquare(-1, (int)entityPos.X, (int)entityPos.Y, 2, TileChangeType.None);
                                        }
                                        else if (Main.tile[(int)entityPos.X, (int)entityPos.Y].type == mod.TileType<Tiles.SandRed>())
                                        {//Red Sand
                                            WorldGen.PlaceTile((int)entityPos.X, (int)entityPos.Y + 1, mod.TileType<Tiles.SandRed>(), true, true);
                                            WorldGen.SquareTileFrame((int)entityPos.X, (int)entityPos.Y, true);
                                            NetMessage.SendTileSquare(-1, (int)entityPos.X, (int)entityPos.Y, 2, TileChangeType.None);
                                        }

                                        ModTileEntity.PlaceEntityNet((int)entityPos.X, (int)entityPos.Y + 1, mod.TileEntityType<Tiles.GravelEntity>());

                                        WorldGen.KillTile((int)entityPos.X, (int)entityPos.Y, false, false, true); //sound is the break sound for tile, use custom
                                    NetMessage.SendData(17, -1, -1, null, 0, (float)(int)entityPos.X, (float)(int)entityPos.Y, 0f, 0, 0, 0);
                                }
                                    else //If not down then this
                                    {
                                        switch (WorldGen.genRand.Next(2)) //choose to fall downleft or down right
                                        {
                                            case 0://Down left, and then down right if fail
                                                if (WorldGen.EmptyTileCheck((int)entityPos.X - 1, (int)entityPos.X - 1, (int)entityPos.Y + 1, (int)entityPos.Y + 1))
                                                {
                                                    if (Main.tile[(int)entityPos.X, (int)entityPos.Y].type == mod.TileType<Tiles.Gravel>())
                                                    {//Gravel
                                                        WorldGen.PlaceTile((int)entityPos.X - 1, (int)entityPos.Y + 1, mod.TileType<Tiles.Gravel>(), true, true);
                                                        WorldGen.SquareTileFrame((int)entityPos.X, (int)entityPos.Y, true);
                                                        NetMessage.SendTileSquare(-1, (int)entityPos.X, (int)entityPos.Y, 2, TileChangeType.None);
                                                }
                                                    else if (Main.tile[(int)entityPos.X, (int)entityPos.Y].type == mod.TileType<Tiles.SandRed>())
                                                    {//Red Sand
                                                        WorldGen.PlaceTile((int)entityPos.X - 1, (int)entityPos.Y + 1, mod.TileType<Tiles.SandRed>(), true, true);
                                                        WorldGen.SquareTileFrame((int)entityPos.X, (int)entityPos.Y, true);
                                                        NetMessage.SendTileSquare(-1, (int)entityPos.X, (int)entityPos.Y, 2, TileChangeType.None);
                                                }
                                                    ModTileEntity.PlaceEntityNet((int)entityPos.X - 1, (int)entityPos.Y + 1, mod.TileEntityType<Tiles.GravelEntity>());

                                                    WorldGen.KillTile((int)entityPos.X, (int)entityPos.Y, false, false, true);
                                                NetMessage.SendData(17, -1, -1, null, 0, (float)(int)entityPos.X, (float)(int)entityPos.Y, 0f, 0, 0, 0);
                                            }
                                                else if (WorldGen.EmptyTileCheck((int)entityPos.X + 1, (int)entityPos.X + 1, (int)entityPos.Y + 1, (int)entityPos.Y + 1))
                                                {
                                                    if (Main.tile[(int)entityPos.X, (int)entityPos.Y].type == mod.TileType<Tiles.Gravel>())
                                                    {//Gravel
                                                        WorldGen.PlaceTile((int)entityPos.X + 1, (int)entityPos.Y + 1, mod.TileType<Tiles.Gravel>(), true, true);
                                                        WorldGen.SquareTileFrame((int)entityPos.X, (int)entityPos.Y, true);
                                                        NetMessage.SendTileSquare(-1, (int)entityPos.X, (int)entityPos.Y, 2, TileChangeType.None);
                                                }
                                                    else if (Main.tile[(int)entityPos.X, (int)entityPos.Y].type == mod.TileType<Tiles.SandRed>())
                                                    {//Red Sand
                                                        WorldGen.PlaceTile((int)entityPos.X + 1, (int)entityPos.Y + 1, mod.TileType<Tiles.SandRed>(), true, true);
                                                        WorldGen.SquareTileFrame((int)entityPos.X, (int)entityPos.Y, true);
                                                        NetMessage.SendTileSquare(-1, (int)entityPos.X, (int)entityPos.Y, 2, TileChangeType.None);
                                                }
                                                    ModTileEntity.PlaceEntityNet((int)entityPos.X + 1, (int)entityPos.Y + 1, mod.TileEntityType<Tiles.GravelEntity>());

                                                    WorldGen.KillTile((int)entityPos.X, (int)entityPos.Y, false, false, true);
                                                NetMessage.SendData(17, -1, -1, null, 0, (float)(int)entityPos.X, (float)(int)entityPos.Y, 0f, 0, 0, 0);
                                            }
                                                break;
                                            case 1://Down right, and then down left if fail
                                                if (WorldGen.EmptyTileCheck((int)entityPos.X + 1, (int)entityPos.X + 1, (int)entityPos.Y + 1, (int)entityPos.Y + 1))
                                                {
                                                    if (Main.tile[(int)entityPos.X, (int)entityPos.Y].type == mod.TileType<Tiles.Gravel>())
                                                    {//Gravel
                                                        WorldGen.PlaceTile((int)entityPos.X + 1, (int)entityPos.Y + 1, mod.TileType<Tiles.Gravel>(), true, true);
                                                        WorldGen.SquareTileFrame((int)entityPos.X, (int)entityPos.Y, true);
                                                        NetMessage.SendTileSquare(-1, (int)entityPos.X, (int)entityPos.Y, 2, TileChangeType.None);
                                                    }
                                                    else if (Main.tile[(int)entityPos.X, (int)entityPos.Y].type == mod.TileType<Tiles.SandRed>())
                                                    {//Red Sand
                                                        WorldGen.PlaceTile((int)entityPos.X + 1, (int)entityPos.Y + 1, mod.TileType<Tiles.SandRed>(), true, true);
                                                        WorldGen.SquareTileFrame((int)entityPos.X, (int)entityPos.Y, true);
                                                        NetMessage.SendTileSquare(-1, (int)entityPos.X, (int)entityPos.Y, 2, TileChangeType.None);
                                                    }
                                                    ModTileEntity.PlaceEntityNet((int)entityPos.X + 1, (int)entityPos.Y + 1, mod.TileEntityType<Tiles.GravelEntity>());

                                                    WorldGen.KillTile((int)entityPos.X, (int)entityPos.Y, false, false, true);
                                                NetMessage.SendData(17, -1, -1, null, 0, (float)(int)entityPos.X, (float)(int)entityPos.Y, 0f, 0, 0, 0);
                                            }
                                                else if (WorldGen.EmptyTileCheck((int)entityPos.X - 1, (int)entityPos.X - 1, (int)entityPos.Y + 1, (int)entityPos.Y + 1))
                                                {
                                                    if (Main.tile[(int)entityPos.X, (int)entityPos.Y].type == mod.TileType<Tiles.Gravel>())
                                                    {//Gravel
                                                        WorldGen.PlaceTile((int)entityPos.X - 1, (int)entityPos.Y + 1, mod.TileType<Tiles.Gravel>(), true, true);
                                                        WorldGen.SquareTileFrame((int)entityPos.X, (int)entityPos.Y, true);
                                                        NetMessage.SendTileSquare(-1, (int)entityPos.X, (int)entityPos.Y, 2, TileChangeType.None);
                                                }
                                                    else if (Main.tile[(int)entityPos.X, (int)entityPos.Y].type == mod.TileType<Tiles.SandRed>())
                                                    {//Red Sand
                                                        WorldGen.PlaceTile((int)entityPos.X - 1, (int)entityPos.Y + 1, mod.TileType<Tiles.SandRed>(), true, true);
                                                        WorldGen.SquareTileFrame((int)entityPos.X, (int)entityPos.Y, true);
                                                        NetMessage.SendTileSquare(-1, (int)entityPos.X, (int)entityPos.Y, 2, TileChangeType.None);
                                                }
                                                    ModTileEntity.PlaceEntityNet((int)entityPos.X - 1, (int)entityPos.Y + 1, mod.TileEntityType<Tiles.GravelEntity>());

                                                    WorldGen.KillTile((int)entityPos.X, (int)entityPos.Y, false, false, true);
                                                    NetMessage.SendData(17, -1, -1, null, 0, (float)(int)entityPos.X, (float)(int)entityPos.Y, 0f, 0, 0, 0);
                                                }
                                                break;
                                        }
                                    }
                                    //else
                                    //{
                                    //Main.NewText("Occupied (Y - 1)" + (int)entityPos.X + ", " + (int)entityPos.Y);
                                    //}
                                }
                            }
                        }
                        DoubleToggle2 = false;
                    }
                    else
                    {
                        DoubleToggle2 = true;
                    }
                    DoubleToggle1 = false;
                }
                else
                {
                    DoubleToggle1 = true;
                }
            //}
        }*/



        /*public override void PostDrawTiles() //gravel version, debug
        {
            Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
            int gravelType1 = mod.TileEntityType<Tiles.GravelEntity>();
            foreach (var item in TileEntity.ByID)
            {
                if(item.Value.type == gravelType1)
                { 
                    var gravel1 = item.Value as Tiles.GravelEntity;
                    Vector2 entityPos = gravel1.TileEntPos();
                    //Main.NewText("Draw Ship" + entityPos.X + entityPos.Y);
                    //ErrorLogger.Log("DrawShip" + entityPos.X + entityPos.Y);
                    Texture2D texture = mod.GetTexture("Items/FlagRed");
                    VisualPlayer modPlayer = Main.LocalPlayer.GetModPlayer<VisualPlayer>();

                    if (modPlayer.ShowBlocks)
                    {
                        Main.spriteBatch.Draw(texture, new Vector2(entityPos.X * 16 - (int)Main.screenPosition.X - 204, (entityPos.Y * 16 - (int)Main.screenPosition.Y) - 220) + zero, new Rectangle(0, 0, texture.Width, texture.Height), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    }
                }
            }
            Main.spriteBatch.End();
        }*/

        public override void PostDrawTiles()
        {
            Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, Main.instance.Rasterizer, null, Main.GameViewMatrix.TransformationMatrix);
            Rectangle screenRect = new Rectangle((int)Main.screenPosition.X, (int)Main.screenPosition.Y, Main.screenWidth, Main.screenHeight);
            Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);

            const int range = 50;

            int shipType1 = ModContent.TileEntityType<Tiles.EntityT1>();
            foreach (var item in TileEntity.ByID)
            {
                if (item.Value.type == shipType1)
                {
                    var ship1 = item.Value as Tiles.EntityT1;
                    Vector2 entityPos = ship1.TileEntPos();
                    Rectangle DrawArea = new Rectangle(((int)entityPos.X + 1) * 16 - range * 16, ((int)entityPos.Y + 1) * 16 - range * 16, range * 16 * 2, range * 16 * 2);

                    //Main.NewText("Draw Ship" + entityPos.X + entityPos.Y);
                    //ErrorLogger.Log("DrawShip" + entityPos.X + entityPos.Y);

                   if (screenRect.Intersects(DrawArea))
                    {
                        Texture2D texture = mod.GetTexture("Tiles/T1");
                        Main.spriteBatch.Draw(texture, new Vector2(entityPos.X * 16 - (int)Main.screenPosition.X - 752, (entityPos.Y * 16 - (int)Main.screenPosition.Y) - 200) + zero, new Rectangle(0, 0, texture.Width, texture.Height), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    }
                }
            }
            Main.spriteBatch.End();
        }

    }
}
