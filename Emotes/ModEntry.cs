using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Netcode;
using StardewValley.Monsters;
using SpaceCore.Events;
using SpaceCore.Interface;
using StardewValley.TerrainFeatures;
using xTile.Tiles;
using xTile;
using StardewValley.Tools;
using StardewValley.Network;
using System.Reflection;
using SpaceShared.APIs;
using StardewModdingAPI.Enums;
using StardewValley.Menus;
using xTile.Layers;
using static StardewValley.Farmer;

namespace Emotes
{
    public class ModEntry : Mod
    {

        internal static IMonitor? ModMonitor { get; set; }
        internal static IModHelper? Helper { get; set; }

        public override void Entry(IModHelper helper)
        {
            var harmony = new Harmony(this.ModManifest.UniqueID);

            ModMonitor = Monitor;
            Helper = helper;

            var reflection = ModEntry.Helper.Reflection;

            helper.Events.GameLoop.GameLaunched += OnGameLaunched;
            helper.Events.GameLoop.UpdateTicked += OnTickUpdated;
            helper.Events.Content.AssetRequested += this.OnAssetRequested;
            helper.Events.Display.RenderedWorld += OnRenderedWorld;


        }

          private void OnGameLaunched(object sender, EventArgs e)
        {
            ModEntry.Helper = Helper;
            // ModEntry.Monitor = Monitor;

            var sc = Helper.ModRegistry.GetApi<ISpaceCoreApi>("spacechase0.SpaceCore");
            //sc.RegisterSerializerType(typeof(NuclearLocation));
            //sc.RegisterSerializerType(typeof(AtomicScienceSilo));
            //sc.RegisterSerializerType(typeof(AdvancedAtomicScienceSilo));

          


            //NuclearBomb.Initialize(this);
        }


        public static void OnTickUpdated(object sender, EventArgs e)

        {


        }


        public void OnAssetRequested(object sender, AssetRequestedEventArgs e)
        {



            //Maps\Custom_SlimeTentInside


            e.Edit(asset =>
            {
                //var editor = asset.AsMap();

                // Map sourceMap = ModEntry.Helper.ModContent.Load<Map>("AtomicScienceSilo.tmx");
                //Map sourceMap2 = ModEntry.Helper.ModContent.Load<Map>("AtomicScienceSilo.tmx");
                //editor.PatchMap(sourceMap, targetArea: new Rectangle(30, 10, 20, 20));
            });

        }

        private void OnRenderedWorld(object? sender, RenderedWorldEventArgs e)
        {
           




                
        }


        public class EmoteTypeK
        {
            public string emoteString = "";

            public int emoteIconIndex = -1;

            public FarmerSprite.AnimationFrame[] animationFrames;

            public bool hidden;

            public int facingDirection = 2;

            public string displayNameKey;

            public string displayName => Game1.content.LoadString(this.displayNameKey);

            public EmoteTypeK(string emote_string = "", string display_name_key = "", int icon_index = -1, FarmerSprite.AnimationFrame[] frames = null, int facing_direction = 2, bool is_hidden = false)
            {
                this.emoteString = emote_string;
                this.emoteIconIndex = icon_index;
                this.animationFrames = frames;
                this.facingDirection = facing_direction;
                this.hidden = is_hidden;
                this.displayNameKey = "Strings\\UI:" + display_name_key;
            }
        }


        public static readonly EmoteTypeK[] EMOTES = new EmoteTypeK[22]
        {
            new EmoteTypeK("happy", "Emote_Happy", 32),
            new EmoteTypeK("sad", "Emote_Sad", 28),
            new EmoteTypeK("heart", "Emote_Heart", 20),
            new EmoteTypeK("exclamation", "Emote_Exclamation", 16),
            new EmoteTypeK("note", "Emote_Note", 56),
            new EmoteTypeK("sleep", "Emote_Sleep", 24),
            new EmoteTypeK("game", "Emote_Game", 52),
            new EmoteTypeK("question", "Emote_Question", 8),
            new EmoteTypeK("x", "Emote_X", 36),
            new EmoteTypeK("pause", "Emote_Pause", 40),
            new EmoteTypeK("blush", "Emote_Blush", 60, null, 2, is_hidden: true),
            new EmoteTypeK("angry", "Emote_Angry", 12),
            new EmoteTypeK("yes", "Emote_Yes", 56, new FarmerSprite.AnimationFrame[7]
            {
                new FarmerSprite.AnimationFrame(0, 250, secondaryArm: false, flip: false).AddFrameAction(delegate(Farmer who)
                {
                    if (who.ShouldHandleAnimationSound())
                    {
                        who.playNearbySoundLocal("jingle1");
                    }
                }),
                new FarmerSprite.AnimationFrame(16, 150, secondaryArm: false, flip: false),
                new FarmerSprite.AnimationFrame(0, 250, secondaryArm: false, flip: false),
                new FarmerSprite.AnimationFrame(16, 150, secondaryArm: false, flip: false),
                new FarmerSprite.AnimationFrame(0, 250, secondaryArm: false, flip: false),
                new FarmerSprite.AnimationFrame(16, 150, secondaryArm: false, flip: false),
                new FarmerSprite.AnimationFrame(0, 250, secondaryArm: false, flip: false)
            }),
            new EmoteTypeK("no", "Emote_No", 36, new FarmerSprite.AnimationFrame[5]
            {
                new FarmerSprite.AnimationFrame(25, 250, secondaryArm: false, flip: false).AddFrameAction(delegate(Farmer who)
                {
                    if (who.ShouldHandleAnimationSound())
                    {
                        who.playNearbySoundLocal("cancel");
                    }
                }),
                new FarmerSprite.AnimationFrame(27, 250, secondaryArm: true, flip: false),
                new FarmerSprite.AnimationFrame(25, 250, secondaryArm: false, flip: false),
                new FarmerSprite.AnimationFrame(27, 250, secondaryArm: true, flip: false),
                new FarmerSprite.AnimationFrame(25, 250, secondaryArm: false, flip: false)
            }),
            new EmoteTypeK("sick", "Emote_Sick", 12, new FarmerSprite.AnimationFrame[8]
            {
                new FarmerSprite.AnimationFrame(104, 350, secondaryArm: false, flip: false).AddFrameAction(delegate(Farmer who)
                {
                    if (who.ShouldHandleAnimationSound())
                    {
                        who.playNearbySoundLocal("croak");
                    }
                }),
                new FarmerSprite.AnimationFrame(105, 350, secondaryArm: false, flip: false),
                new FarmerSprite.AnimationFrame(104, 350, secondaryArm: false, flip: false),
                new FarmerSprite.AnimationFrame(105, 350, secondaryArm: false, flip: false),
                new FarmerSprite.AnimationFrame(104, 350, secondaryArm: false, flip: false),
                new FarmerSprite.AnimationFrame(105, 350, secondaryArm: false, flip: false),
                new FarmerSprite.AnimationFrame(104, 350, secondaryArm: false, flip: false),
                new FarmerSprite.AnimationFrame(105, 350, secondaryArm: false, flip: false)
            }),
            new EmoteTypeK("laugh", "Emote_Laugh", 56, new FarmerSprite.AnimationFrame[8]
            {
                new FarmerSprite.AnimationFrame(102, 150, secondaryArm: false, flip: false).AddFrameAction(delegate(Farmer who)
                {
                    if (who.ShouldHandleAnimationSound())
                    {
                        who.playNearbySoundLocal("dustMeep");
                    }
                }),
                new FarmerSprite.AnimationFrame(103, 150, secondaryArm: false, flip: false),
                new FarmerSprite.AnimationFrame(102, 150, secondaryArm: false, flip: false).AddFrameAction(delegate(Farmer who)
                {
                    if (who.ShouldHandleAnimationSound())
                    {
                        who.playNearbySoundLocal("dustMeep");
                    }
                }),
                new FarmerSprite.AnimationFrame(103, 150, secondaryArm: false, flip: false),
                new FarmerSprite.AnimationFrame(102, 150, secondaryArm: false, flip: false).AddFrameAction(delegate(Farmer who)
                {
                    if (who.ShouldHandleAnimationSound())
                    {
                        who.playNearbySoundLocal("dustMeep");
                    }
                }),
                new FarmerSprite.AnimationFrame(103, 150, secondaryArm: false, flip: false),
                new FarmerSprite.AnimationFrame(102, 150, secondaryArm: false, flip: false).AddFrameAction(delegate(Farmer who)
                {
                    if (who.ShouldHandleAnimationSound())
                    {
                        who.playNearbySoundLocal("dustMeep");
                    }
                }),
                new FarmerSprite.AnimationFrame(103, 150, secondaryArm: false, flip: false)
            }),
            new EmoteTypeK("surprised", "Emote_Surprised", 16, new FarmerSprite.AnimationFrame[1] { new FarmerSprite.AnimationFrame(94, 1500, secondaryArm: false, flip: false).AddFrameAction(delegate(Farmer who)
            {
                if (who.ShouldHandleAnimationSound())
                {
                    who.playNearbySoundLocal("batScreech");
                }
                who.jumpWithoutSound(4f);
                who.jitterStrength = 1f;
            }) }),
            new EmoteTypeK("hi", "Emote_Hi", 56, new FarmerSprite.AnimationFrame[4]
            {
                new FarmerSprite.AnimationFrame(3, 250, secondaryArm: false, flip: false).AddFrameAction(delegate(Farmer who)
                {
                    if (who.ShouldHandleAnimationSound())
                    {
                        who.playNearbySoundLocal("give_gift");
                    }
                }),
                new FarmerSprite.AnimationFrame(85, 250, secondaryArm: false, flip: false),
                new FarmerSprite.AnimationFrame(3, 250, secondaryArm: false, flip: false),
                new FarmerSprite.AnimationFrame(85, 250, secondaryArm: false, flip: false)
            }),
            new EmoteTypeK("taunt", "Emote_Taunt", 12, new FarmerSprite.AnimationFrame[10]
            {
                new FarmerSprite.AnimationFrame(3, 250, secondaryArm: false, flip: false),
                new FarmerSprite.AnimationFrame(102, 50, secondaryArm: false, flip: false),
                new FarmerSprite.AnimationFrame(10, 250, secondaryArm: false, flip: false).AddFrameAction(delegate(Farmer who)
                {
                    if (who.ShouldHandleAnimationSound())
                    {
                        who.playNearbySoundLocal("hitEnemy");
                    }
                    who.jitterStrength = 1f;
                }).AddFrameEndAction(delegate(Farmer who)
                {
                    who.stopJittering();
                }),
                new FarmerSprite.AnimationFrame(3, 250, secondaryArm: false, flip: false),
                new FarmerSprite.AnimationFrame(102, 50, secondaryArm: false, flip: false),
                new FarmerSprite.AnimationFrame(10, 250, secondaryArm: false, flip: false).AddFrameAction(delegate(Farmer who)
                {
                    if (who.ShouldHandleAnimationSound())
                    {
                        who.playNearbySoundLocal("hitEnemy");
                    }
                    who.jitterStrength = 1f;
                }).AddFrameEndAction(delegate(Farmer who)
                {
                    who.stopJittering();
                }),
                new FarmerSprite.AnimationFrame(3, 250, secondaryArm: false, flip: false),
                new FarmerSprite.AnimationFrame(102, 50, secondaryArm: false, flip: false),
                new FarmerSprite.AnimationFrame(10, 250, secondaryArm: false, flip: false).AddFrameAction(delegate(Farmer who)
                {
                    if (who.ShouldHandleAnimationSound())
                    {
                        who.playNearbySoundLocal("hitEnemy");
                    }
                    who.jitterStrength = 1f;
                }).AddFrameEndAction(delegate(Farmer who)
                {
                    who.stopJittering();
                }),
                new FarmerSprite.AnimationFrame(3, 500, secondaryArm: false, flip: false)
            }, 2, is_hidden: true),
            new EmoteTypeK("uh", "Emote_Uh", 40, new FarmerSprite.AnimationFrame[1] { new FarmerSprite.AnimationFrame(10, 1500, secondaryArm: false, flip: false).AddFrameAction(delegate(Farmer who)
            {
                if (who.ShouldHandleAnimationSound())
                {
                    who.playNearbySoundLocal("clam_tone");
                }
            }) }),
            new EmoteTypeK("music", "Emote_Music", 56, new FarmerSprite.AnimationFrame[9]
            {
                new FarmerSprite.AnimationFrame(98, 150, secondaryArm: false, flip: false).AddFrameAction(delegate(Farmer who)
                {


                    //Game1.player.playHarpEmoteSound();
                }),
                new FarmerSprite.AnimationFrame(99, 150, secondaryArm: false, flip: false),
                new FarmerSprite.AnimationFrame(100, 150, secondaryArm: false, flip: false),
                new FarmerSprite.AnimationFrame(98, 150, secondaryArm: false, flip: false),
                new FarmerSprite.AnimationFrame(99, 150, secondaryArm: false, flip: false),
                new FarmerSprite.AnimationFrame(100, 150, secondaryArm: false, flip: false),
                new FarmerSprite.AnimationFrame(98, 150, secondaryArm: false, flip: false),
                new FarmerSprite.AnimationFrame(99, 150, secondaryArm: false, flip: false),
                new FarmerSprite.AnimationFrame(100, 150, secondaryArm: false, flip: false)
            }, 2, is_hidden: true),
            new EmoteTypeK("jar", "Emote_Jar", -1, new FarmerSprite.AnimationFrame[6]
            {
                new FarmerSprite.AnimationFrame(111, 150, secondaryArm: false, flip: false),
                new FarmerSprite.AnimationFrame(111, 300, secondaryArm: false, flip: false).AddFrameAction(delegate(Farmer who)
                {
                    if (who.ShouldHandleAnimationSound())
                    {
                        who.playNearbySoundLocal("fishingRodBend");
                    }
                    who.jitterStrength = 1f;
                }).AddFrameEndAction(delegate(Farmer who)
                {
                    who.stopJittering();
                }),
                new FarmerSprite.AnimationFrame(111, 500, secondaryArm: false, flip: false),
                new FarmerSprite.AnimationFrame(111, 300, secondaryArm: false, flip: false).AddFrameAction(delegate(Farmer who)
                {
                    if (who.ShouldHandleAnimationSound())
                    {
                        who.playNearbySoundLocal("fishingRodBend");
                    }
                    who.jitterStrength = 1f;
                }).AddFrameEndAction(delegate(Farmer who)
                {
                    who.stopJittering();
                }),
                new FarmerSprite.AnimationFrame(111, 500, secondaryArm: false, flip: false),
                new FarmerSprite.AnimationFrame(112, 1000, secondaryArm: false, flip: false).AddFrameAction(delegate(Farmer who)
                {
                    if (who.ShouldHandleAnimationSound())
                    {
                        who.playNearbySoundLocal("coin");
                    }
                    who.jumpWithoutSound(4f);
                })
            }, 1, is_hidden: true)
        };




        public virtual void draw(SpriteBatch b, int ySourceRectOffset, float alpha = 1f)
        {
            Microsoft.Xna.Framework.Rectangle box;
            box = Game1.player.GetBoundingBox();
            Game1.player.Sprite.draw(b, Game1.GlobalToLocal(Game1.viewport, Game1.player.Position) + new Vector2(Game1.player.GetSpriteWidthForPositioning() * 4 / 2, box.Height / 2), (float)box.Center.Y / 10000f, 0, ySourceRectOffset, Color.White, flip: false, 4f, 0f, characterSourceRectOffset: true);
            if (Game1.player.IsEmoting)
            {
                Vector2 emotePosition;
                emotePosition = Game1.player.getLocalPosition(Game1.viewport);
                emotePosition.Y -= 96f;
                b.Draw(Game1.emoteSpriteSheet, emotePosition, new Microsoft.Xna.Framework.Rectangle(Game1.player.CurrentEmoteIndex * 16 % Game1.emoteSpriteSheet.Width, Game1.player.CurrentEmoteIndex * 16 / Game1.emoteSpriteSheet.Width * 16, 16, 16), Color.White * alpha, 0f, Vector2.Zero, 4f, SpriteEffects.None, (float)Game1.player.StandingPixel.Y / 10000f);
            }
        }












    }
}
