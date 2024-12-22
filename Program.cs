using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace ItemListHelper
{
    public static class Program
    {
        public static readonly string BasePath = "E:\\Minecraft_Item_List";

        public static readonly Point Phase1Size = new Point(1080, 1920);
        public static readonly Rectangle Phase1Rect = new Rectangle(0, 0, Phase1Size.X, Phase1Size.Y);

        public static readonly Point Phase2Size = new Point(1000, 480);
        public static readonly Rectangle Phase2Rect = new Rectangle(0, 0, Phase2Size.X, Phase2Size.Y);
        public static readonly Point Phase2CropLocation = new Point(200, 540);
        public static readonly Rectangle Phase2CropRect = new Rectangle(Phase2CropLocation.X, Phase2CropLocation.Y, Phase2Size.X, Phase2Size.Y);

        public static readonly int Phase3ScaleFactor = 4;
        public static readonly Point Phase3Size = new Point(Phase2Size.X / Phase3ScaleFactor, Phase2Size.Y / Phase3ScaleFactor);
        public static readonly Rectangle Phase3Rect = new Rectangle(0, 0, Phase3Size.X, Phase3Size.Y);

        public static readonly Point Phase4Size = new Point(Phase3Size.X, Phase3Size.Y);
        public static readonly Rectangle Phase4Rect = new Rectangle(0, 0, Phase4Size.X, Phase4Size.Y);

        public static readonly Point Phase5Size = new Point(Phase4Size.X, Phase4Size.Y / 10);
        public static readonly Rectangle Phase5Rect = new Rectangle(0, 0, Phase5Size.X, Phase5Size.Y);

        public static readonly Point Font1Size = new Point(1904, 48);
        public static readonly Rectangle Font1Rect = new Rectangle(0, 0, Font1Size.X, Font1Size.Y);
        public static readonly Point Font1CropLocation = new Point(8, 1024);
        public static readonly Rectangle Font1CropRect = new Rectangle(Font1CropLocation.X, Font1CropLocation.Y, Font1Size.X, Font1Size.Y);

        public static readonly int Font2ScaleFactor = 4;
        public static readonly Point Font2Size = new Point(Font1Size.X / Font2ScaleFactor, Font1Size.Y / Font2ScaleFactor);
        public static readonly Rectangle Font2Rect = new Rectangle(0, 0, Font2Size.X, Font2Size.Y);

        public static void Main(string[] args)
        {
            // summon block_display ~-0.5 ~-0.5 ~-0.5 {Passengers:[{id:"minecraft:block_display",block_state:{Name:"minecraft:light_blue_concrete",Properties:{}},transformation:[0.7071f,0.0000f,0.7071f,0.0000f,0.0000f,1.0000f,0.0000f,0.0000f,-0.7071f,0.0000f,0.7071f,0.0000f,0.0000f,0.0000f,0.0000f,1.0000f]},{id:"minecraft:block_display",block_state:{Name:"minecraft:light_blue_concrete",Properties:{}},transformation:[0.7071f,0.0000f,0.7071f,-0.8125f,0.0000f,1.0000f,0.0000f,0.5000f,-0.7071f,0.0000f,0.7071f,0.0000f,0.0000f,0.0000f,0.0000f,1.0000f]}]}
            string bdsCommand = Console.ReadLine();
            bdsCommand.IndexOf('{');


            StringBuilder sb = new StringBuilder();
            sb.Append("summon minecraft:dolphin ~ ~ ~ {NoAI:1b,PersistenceRequired:1b,CanPickUpLoot:0b,Silent:1b,Invulnerable:1b,ActiveEffects:[{Id:14,Amplifier:0,Duration:2147483647,ShowParticles:0b}],Tags:[\"SharksDatapack\",\"Shark\"],Passengers:[");
            Place(sb, -0.5, -0.5, -1.5, 1, 0.5, 3); sb.Append(","); // Body
            Place(sb, -1, -0.5, 1.5, 2, 0.5, 0.5); sb.Append(","); // Head
            Place(sb, -1 - 0.125, -0.5 + 0.125, 1.5 + 0.125, 0.125, 0.25, 0.25); sb.Append(","); // Eyes
            Place(sb, 1, -0.5 + 0.125, 1.5 + 0.125, 0.125, 0.25, 0.25); sb.Append(",");
            sb.Append("]}");
            File.WriteAllText("C:\\Users\\RandomiaGaming\\AppData\\Roaming\\.minecraft\\saves\\Sharks\\datapacks\\sharks\\data\\sharks\\functions\\spawn_shark.mcfunction", sb.ToString());
        }
        public enum Axis
        {
            X, Y, Z
        }
        public static void Place(StringBuilder sb, double x = 0.0, double y = 0.0, double z = 0.0, double sX = 1.0, double sY = 1.0, double sZ = 1.0, double angle = 0.0, Axis axis = Axis.X)
        {
            sb.Append("{id:\"minecraft:block_display\",Tags:[\"SharksDatapack\",\"SharkBlockDisplay\"],block_state:{Name:\"minecraft:tinted_glass\"},");
            sb.Append("transformation:{left_rotation:{angle:0.0000f,axis:[0.0000f,0.0000f,0.0000f]},");
            angle = (angle * Math.PI) / 180.0;
            sb.Append($"right_rotation:{{angle:{angle:F4},axis:[");
            switch (axis)
            {
                case Axis.X: sb.Append("1.0000f,0.0000f,0.0000f"); break;
                case Axis.Y: sb.Append("0.0000f,1.0000f,0.0000f"); break;
                case Axis.Z: default: sb.Append("0.0000f,0.0000f,1.0000f"); break;
            }
            sb.Append("]},");
            sb.Append($"scale:[{sX:F4}f,{sY:F4}f,{sZ:F4}f],");
            sb.Append($"translation:[{x:F4}f,{y:F4}f,{z:F4}f]");
            sb.Append("}}");
        }

        public static void OldMain()
        {
            List<string> commands = new List<string>();

            commands.AddRange(CheckLine(LetteredItemList.A_Items, -60, 72, -382 + (4 * 0)));
            commands.AddRange(CheckLine(LetteredItemList.B_Items, -60, 72, -382 + (4 * 0) + 3));
            commands.AddRange(CheckLine(LetteredItemList.C_Items, -60, 72, -382 + (4 * 1)));
            commands.AddRange(CheckLine(LetteredItemList.D_Items, -60, 72, -382 + (4 * 1) + 3));
            commands.AddRange(CheckLine(LetteredItemList.E_Items, -60, 72, -382 + (4 * 2)));
            commands.AddRange(CheckLine(LetteredItemList.F_Items, -60, 72, -382 + (4 * 2) + 3));
            commands.AddRange(CheckLine(LetteredItemList.G_Items, -60, 72, -382 + (4 * 3)));
            commands.AddRange(CheckLine(LetteredItemList.H_Items, -60, 72, -382 + (4 * 3) + 3));
            commands.AddRange(CheckLine(LetteredItemList.I_Items, -60, 72, -382 + (4 * 4)));
            commands.AddRange(CheckLine(LetteredItemList.J_Items, -60, 72, -382 + (4 * 4) + 3));
            commands.AddRange(CheckLine(LetteredItemList.K_Items, -60, 72, -382 + (4 * 5)));
            commands.AddRange(CheckLine(LetteredItemList.L_Items, -60, 72, -382 + (4 * 5) + 3));
            commands.AddRange(CheckLine(LetteredItemList.M_Items, -60, 72, -382 + (4 * 6)));
            commands.AddRange(CheckLine(LetteredItemList.N_Items, -60, 72, -382 + (4 * 6) + 3));
            commands.AddRange(CheckLine(LetteredItemList.O_Items, -60, 72, -382 + (4 * 7)));
            commands.AddRange(CheckLine(LetteredItemList.P_Items, -60, 72, -382 + (4 * 7) + 3));
            commands.AddRange(CheckLine(LetteredItemList.Q_Items, -60, 72, -382 + (4 * 8)));
            commands.AddRange(CheckLine(LetteredItemList.R_Items, -60, 72, -382 + (4 * 8) + 3));
            commands.AddRange(CheckLine(LetteredItemList.S_Items, -60, 72, -382 + (4 * 9)));
            commands.AddRange(CheckLine(LetteredItemList.T_Items, -60, 72, -382 + (4 * 9) + 3));
            commands.AddRange(CheckLine(LetteredItemList.U_Items, -60, 72, -382 + (4 * 10)));
            commands.AddRange(CheckLine(LetteredItemList.V_Items, -60, 72, -382 + (4 * 10) + 3));
            commands.AddRange(CheckLine(LetteredItemList.W_Items, -60, 72, -382 + (4 * 11)));
            commands.AddRange(CheckLine(LetteredItemList.X_Items, -60, 72, -382 + (4 * 11) + 3));
            commands.AddRange(CheckLine(LetteredItemList.Y_Items, -60, 72, -382 + (4 * 12)));
            commands.AddRange(CheckLine(LetteredItemList.Z_Items, -60, 72, -382 + (4 * 12) + 3));

            File.WriteAllLines("D:\\Datapacks\\itemstorage\\data\\itemstorage\\functions\\ismark.mcfunction", commands.ToArray());
        }
        public static string[] CheckLine(List<string> items, int x, int y, int z)
        {
            List<string> output = new List<string>();

            int itemIndex = 0;
            while (items.Count - itemIndex > 8)
            {
                output.AddRange(GenerateSignCommand(x, y, z, items[itemIndex]));
                output.AddRange(GenerateSignCommand(x + 1, y, z, items[itemIndex + 1]));
                output.AddRange(GenerateSignCommand(x + 2, y, z, items[itemIndex + 2]));
                output.AddRange(GenerateSignCommand(x + 3, y, z, items[itemIndex + 3]));
                output.AddRange(GenerateSignCommand(x + 4, y, z, items[itemIndex + 4]));
                output.AddRange(GenerateSignCommand(x + 5, y, z, items[itemIndex + 5]));
                output.AddRange(GenerateSignCommand(x + 6, y, z, items[itemIndex + 6]));
                output.AddRange(GenerateSignCommand(x + 7, y, z, items[itemIndex + 7]));
                itemIndex += 8;
                x += 10;
            }

            for (int i = itemIndex; i < items.Count; i++)
            {
                output.AddRange(GenerateSignCommand(x, y, z, items[i]));
                x++;
            }

            return output.ToArray();
        }
        public static class LetteredItemList
        {
            public static List<string> All_Items = new List<string>();

            public static List<string> A_Items = new List<string>();
            public static List<string> B_Items = new List<string>();
            public static List<string> C_Items = new List<string>();
            public static List<string> D_Items = new List<string>();
            public static List<string> E_Items = new List<string>();
            public static List<string> F_Items = new List<string>();
            public static List<string> G_Items = new List<string>();
            public static List<string> H_Items = new List<string>();
            public static List<string> I_Items = new List<string>();
            public static List<string> J_Items = new List<string>();
            public static List<string> K_Items = new List<string>();
            public static List<string> L_Items = new List<string>();
            public static List<string> M_Items = new List<string>();
            public static List<string> N_Items = new List<string>();
            public static List<string> O_Items = new List<string>();
            public static List<string> P_Items = new List<string>();
            public static List<string> Q_Items = new List<string>();
            public static List<string> R_Items = new List<string>();
            public static List<string> S_Items = new List<string>();
            public static List<string> T_Items = new List<string>();
            public static List<string> U_Items = new List<string>();
            public static List<string> V_Items = new List<string>();
            public static List<string> W_Items = new List<string>();
            public static List<string> X_Items = new List<string>();
            public static List<string> Y_Items = new List<string>();
            public static List<string> Z_Items = new List<string>();

            public static List<string> Other_Items = new List<string>();

            public static List<List<string>> All_Letter_Groups = new List<List<string>>()
            {
                A_Items,
                B_Items,
                C_Items,
                D_Items,
                E_Items,
                F_Items,
                G_Items,
                H_Items,
                I_Items,
                J_Items,
                K_Items,
                L_Items,
                M_Items,
                N_Items,
                O_Items,
                P_Items,
                Q_Items,
                R_Items,
                S_Items,
                T_Items,
                U_Items,
                V_Items,
                W_Items,
                X_Items,
                Y_Items,
                Z_Items,
            };

            static LetteredItemList()
            {
                All_Items = new List<string>(File.ReadAllLines("E:\\Minecraft_Item_List\\ItemList.txt"));

                foreach (string foreachItem in All_Items)
                {
                    string item = foreachItem.Replace('_', ' ');

                    char c = char.ToUpper(item[0]);

                    if (c is 'A')
                    {
                        A_Items.Add(item);
                    }
                    else if (c is 'B')
                    {
                        B_Items.Add(item);
                    }
                    else if (c is 'C')
                    {
                        C_Items.Add(item);
                    }
                    else if (c is 'D')
                    {
                        D_Items.Add(item);
                    }
                    else if (c is 'E')
                    {
                        E_Items.Add(item);
                    }
                    else if (c is 'F')
                    {
                        F_Items.Add(item);
                    }
                    else if (c is 'G')
                    {
                        G_Items.Add(item);
                    }
                    else if (c is 'H')
                    {
                        H_Items.Add(item);
                    }
                    else if (c is 'I')
                    {
                        I_Items.Add(item);
                    }
                    else if (c is 'J')
                    {
                        J_Items.Add(item);
                    }
                    else if (c is 'K')
                    {
                        K_Items.Add(item);
                    }
                    else if (c is 'L')
                    {
                        L_Items.Add(item);
                    }
                    else if (c is 'M')
                    {
                        M_Items.Add(item);
                    }
                    else if (c is 'N')
                    {
                        N_Items.Add(item);
                    }
                    else if (c is 'O')
                    {
                        O_Items.Add(item);
                    }
                    else if (c is 'P')
                    {
                        P_Items.Add(item);
                    }
                    else if (c is 'Q')
                    {
                        Q_Items.Add(item);
                    }
                    else if (c is 'R')
                    {
                        R_Items.Add(item);
                    }
                    else if (c is 'S')
                    {
                        S_Items.Add(item);
                    }
                    else if (c is 'T')
                    {
                        T_Items.Add(item);
                    }
                    else if (c is 'U')
                    {
                        U_Items.Add(item);
                    }
                    else if (c is 'V')
                    {
                        V_Items.Add(item);
                    }
                    else if (c is 'W')
                    {
                        W_Items.Add(item);
                    }
                    else if (c is 'X')
                    {
                        X_Items.Add(item);
                    }
                    else if (c is 'Y')
                    {
                        Y_Items.Add(item);
                    }
                    else if (c is 'Z')
                    {
                        Z_Items.Add(item);
                    }
                    else
                    {
                        Other_Items.Add(item);
                        Console.WriteLine($"Warning weird item with name: {item}.");
                    }
                }

                All_Items.Sort();

                A_Items.Sort();
                B_Items.Sort();
                C_Items.Sort();
                D_Items.Sort();
                E_Items.Sort();
                F_Items.Sort();
                G_Items.Sort();
                H_Items.Sort();
                I_Items.Sort();
                J_Items.Sort();
                K_Items.Sort();
                L_Items.Sort();
                M_Items.Sort();
                N_Items.Sort();
                O_Items.Sort();
                P_Items.Sort();
                Q_Items.Sort();
                R_Items.Sort();
                S_Items.Sort();
                T_Items.Sort();
                U_Items.Sort();
                V_Items.Sort();
                W_Items.Sort();
                X_Items.Sort();
                Y_Items.Sort();
                Z_Items.Sort();

                Other_Items.Sort();
            }
        }
        public sealed class BlockData
        {
            public int X;
            public int Y;
            public int Z;
            public string Name;
            public string Data;
            public string NBT;
            public BlockData(int x, int y, int z, string name, string data = "", string nbt = "")
            {
                X = x;
                Y = y;
                Z = z;
                Name = name;
                Data = data;
                NBT = nbt;
            }
        }
        public static class Schematic
        {
            public static List<BlockData> SchematicData = new List<BlockData>();
            public static void SetBlock(int x, int y, int z, string name, string data = "", string nbt = "")
            {
                for (int i = 0; i < SchematicData.Count; i++)
                {
                    if (SchematicData[i].X == x && SchematicData[i].Y == y && SchematicData[i].Z == z)
                    {
                        SchematicData.RemoveAt(i);
                        break;
                    }
                }

                SchematicData.Add(new BlockData(x, y, z, name, data, nbt));
            }
            public static void SetBlockNDO(int x, int y, int z, string name, string data = "", string nbt = "")
            {
                for (int i = 0; i < SchematicData.Count; i++)
                {
                    if (SchematicData[i].X == x && SchematicData[i].Y == y && SchematicData[i].Z == z)
                    {
                        return;
                    }
                }

                SchematicData.Add(new BlockData(x, y, z, name, data, nbt));
            }
            public static void Fill(int xMin, int yMin, int zMin, int xMax, int yMax, int zMax, string name, string data = "", string nbt = "")
            {
                for (int x = xMin; x < xMax; x++)
                {
                    for (int y = yMin; y < yMax; y++)
                    {
                        for (int z = zMin; z < zMax; z++)
                        {
                            SetBlock(x, y, z, name, data, nbt);
                        }
                    }
                }
            }
        }
        public static void CreateSchematicCheck()
        {
            List<string> output = new List<string>();

            foreach (BlockData blockData in Schematic.SchematicData)
            {
                output.Add($"execute positioned {blockData.X} {blockData.Y} {blockData.Z} run execute unless block ~ ~ ~ minecraft:{blockData.Name}[] run summon minecraft:armor_stand ~ ~-0.5 ~ {{Marker:1b,Invisible:1b,Invulnerable:1b,NoBasePlate:1b,Small:1b,ArmorItems:[{{}},{{}},{{}},{{id:\"minecraft:{blockData.Name}\",Count:1b}}],HandItems:[{{}},{{}}],Tags:[\"ItemStorage\",\"NullMarker\"],ActiveEffects:[{{Id:24,Amplifier:0,Duration:2147483647}}]}}");
                output.Add($"execute positioned {blockData.X} {blockData.Y} {blockData.Z} run execute unless block ~ ~ ~ minecraft:{blockData.Name}[] run tellraw @a \"Invalid block found at {blockData.X} {blockData.Y} {blockData.Z}.\"");
            }

            File.WriteAllLines("D:\\Datapacks\\itemstorage\\data\\itemstorage\\functions\\ismark.mcfunction", output.ToArray());
        }
        //Generates a command to set the contents of a sign to a string. Also splits the text onto multiple lines as needed.
        public struct CharWidth
        {
            public char Character;
            public int Width;
            public CharWidth(char character, int width)
            {
                Character = character;
                Width = width;
            }
        }
        public static readonly CharWidth[] fontWidths = new CharWidth[]
        {
            new CharWidth(' ', 4),
            new CharWidth(':', 1),
            new CharWidth('_', 5),
            new CharWidth('0', 5),
            new CharWidth('1', 5),
            new CharWidth('2', 5),
            new CharWidth('3', 5),
            new CharWidth('4', 5),
            new CharWidth('5', 5),
            new CharWidth('6', 5),
            new CharWidth('7', 5),
            new CharWidth('8', 5),
            new CharWidth('9', 5),
            new CharWidth('A', 5),
            new CharWidth('B', 5),
            new CharWidth('C', 5),
            new CharWidth('D', 5),
            new CharWidth('E', 5),
            new CharWidth('F', 5),
            new CharWidth('G', 5),
            new CharWidth('H', 5),
            new CharWidth('I', 3),
            new CharWidth('J', 5),
            new CharWidth('K', 5),
            new CharWidth('L', 5),
            new CharWidth('M', 5),
            new CharWidth('N', 5),
            new CharWidth('O', 5),
            new CharWidth('P', 5),
            new CharWidth('Q', 5),
            new CharWidth('R', 5),
            new CharWidth('S', 5),
            new CharWidth('T', 5),
            new CharWidth('U', 5),
            new CharWidth('V', 5),
            new CharWidth('W', 5),
            new CharWidth('X', 5),
            new CharWidth('Y', 5),
            new CharWidth('Z', 5),
            new CharWidth('a', 5),
            new CharWidth('b', 5),
            new CharWidth('c', 5),
            new CharWidth('d', 5),
            new CharWidth('e', 5),
            new CharWidth('f', 4),
            new CharWidth('g', 5),
            new CharWidth('h', 5),
            new CharWidth('i', 1),
            new CharWidth('j', 5),
            new CharWidth('k', 4),
            new CharWidth('l', 2),
            new CharWidth('m', 5),
            new CharWidth('n', 5),
            new CharWidth('o', 5),
            new CharWidth('p', 5),
            new CharWidth('q', 5),
            new CharWidth('r', 5),
            new CharWidth('s', 5),
            new CharWidth('t', 3),
            new CharWidth('u', 5),
            new CharWidth('v', 5),
            new CharWidth('w', 5),
            new CharWidth('x', 5),
            new CharWidth('y', 5),
            new CharWidth('z', 5)
        };
        public const int maxLineWidth = 88;
        public const int letterGapWidth = 1;

        public struct Word
        {
            public string Text;
            public int Width;
            public Word(string text)
            {
                Width = 0;
                Text = text;
                foreach (char character in Text)
                {
                    foreach (CharWidth charWidth in fontWidths)
                    {
                        if (charWidth.Character == character)
                        {
                            Width += charWidth.Width + letterGapWidth;
                            break;
                        }
                    }
                }
            }
        }
        public static string[] SplitStringForSigns(string text)
        {
            string[] wordStrings = text.Split(' ');

            Word[] words = new Word[wordStrings.Length];
            for (int i = 0; i < wordStrings.Length; i++)
            {
                words[i] = new Word(wordStrings[i]);
            }

            int lineIndex = 0;
            int lineLength = 0;

            string[] output = new string[4];

            for (int i = 0; i < words.Length; i++)
            {
                if (lineLength + words[i].Width > maxLineWidth)
                {
                    lineIndex++;
                    lineLength = 0;
                }

                output[lineIndex] += words[i].Text + " ";
                lineLength += words[i].Width + 4;
            }

            return output;
        }
        public static string[] GenerateSignCommand(int x, int y, int z, string text)
        {
            string[] lines = SplitStringForSigns(text);
            return GenerateSignCommand(x, y, z, lines[0], lines[1], lines[2], lines[3]);
        }
        public static string[] GenerateSignCommand(int x, int y, int z, string line0, string line1, string line2, string line3)
        {
            string[] output = new string[2];
            output[0] = $"execute unless block {x} {y} {z} #minecraft:wall_signs run tellraw @a \"Error block {x} {y} {z} is not a sign.\"";

            string baseNBT = $"is_waxed:1b,x:{x},y:{y},z:{z},id:\"minecraft:sign\"";
            string messagesNBT = "[\'{\"text\":\"" + line0 + "\",\"clickEvent\":{\"action\":\"run_command\",\"value\":\"function itemstorage:istoggle\"}}\'," +
                             "\'{\"text\":\"" + line1 + "\"}\'," +
                             "\'{\"text\":\"" + line2 + "\"}\'," +
                             "\'{\"text\":\"" + line3 + "\"}\']";
            string sideNBT = $"has_glowing_text:0b,color:\"black\",messages:{messagesNBT}";
            string frontNBT = "front_text:{" + sideNBT + "}, ";
            string backNBT = "back_text:{" + sideNBT + "}, ";
            string finalNBT = "{" + frontNBT + backNBT + baseNBT + "}";

            output[1] = $"execute if block {x} {y} {z} #minecraft:wall_signs run data merge block {x} {y} {z} {finalNBT}";

            return output;
        }
        //Splits up a large amount of items into stacks. For example 80 items is 1 stack of 64 and 16 items.
        public struct StackSplit
        {
            public int Stacks;
            public int Remainder;
        }
        public static StackSplit SplitIntoStacks(int items, int stackSize = 64)
        {
            StackSplit output = new StackSplit();
            output.Stacks = items / stackSize;
            output.Remainder = items - (stackSize * output.Stacks);
            return output;
        }
        //Alphabetize the list.
        public static void Phase11()
        {
            int phaseNumber = 11;

            string input = File.ReadAllText($"{BasePath}\\Phase{phaseNumber - 1}.txt");

            string[] inputArray = input.Split('\n');

            Array.Sort(inputArray);

            string output = "";

            foreach (string line in inputArray)
            {
                output += line + "\n";
            }

            if (output.Length > 0)
            {
                output = output.Substring(0, output.Length - 1);
            }

            File.WriteAllText($"{BasePath}\\Phase{phaseNumber}.txt", output);
        }
        public sealed class CharTexture
        {
            public char Character;
            public Bitmap Texture;
            public CharTexture(char character, Bitmap texture)
            {
                Character = character;
                Texture = texture;
            }
        }
        //OCR each image into text.
        public static void Phase10()
        {
            int phaseNumber = 10;

            //Load font
            List<CharTexture> font = new List<CharTexture>();
            foreach (char c in "ABCDEFGHIJKLMNOPQRSTUVWXYZ")
            {
                font.Add(new CharTexture(c, new Bitmap($"{BasePath}\\Font\\Upper_{c}.png")));
            }
            foreach (char c in "abcdefghijklmnopqrstuvwxyz")
            {
                font.Add(new CharTexture(c, new Bitmap($"{BasePath}\\Font\\Lower_{c}.png")));
            }
            foreach (char c in "0123456789")
            {
                font.Add(new CharTexture(c, new Bitmap($"{BasePath}\\Font\\Number_{c}.png")));
            }
            font.Add(new CharTexture(';', new Bitmap($"{BasePath}\\Font\\Colon.png")));
            font.Add(new CharTexture('_', new Bitmap($"{BasePath}\\Font\\Underscore.png")));

            string output = "";

            int i = 0;
            string[] folders = Directory.GetDirectories($"{BasePath}\\Phase{phaseNumber - 1}");
            foreach (string folder in folders)
            {
                int j = 0;
                while (true)
                {
                    if (!File.Exists($"{folder}\\{j}.png"))
                    {
                        break;
                    }

                    Bitmap charImg = new Bitmap($"{folder}\\{j}.png");

                    bool foundChar = false;

                    foreach (CharTexture charTexture in font)
                    {
                        if (charImg.Width != charTexture.Texture.Width || charImg.Height != charTexture.Texture.Height)
                        {
                            goto NextCharTexture;
                        }

                        for (int x = 0; x < charImg.Width; x++)
                        {
                            for (int y = 0; y < charImg.Height; y++)
                            {
                                Color a = charImg.GetPixel(x, y);
                                Color b = charTexture.Texture.GetPixel(x, y);

                                if (a.R != b.R || a.G != b.G || a.B != b.B)
                                {
                                    goto NextCharTexture;
                                }
                            }
                        }

                        output += charTexture.Character;
                        foundChar = true;
                        break;
                    NextCharTexture:;
                    }

                    if (!foundChar)
                    {

                    }

                    j++;
                }

                output += "\n";

                Console.WriteLine($"Phase{phaseNumber} - OCR Complete For Image - {i} of {folders.Length}");
                i++;
            }

            if (output.Length > 0)
            {
                output = output.Substring(0, output.Length - 1);
            }

            File.WriteAllText($"{BasePath}\\Phase{phaseNumber}.txt", output);
        }
        //Splits all images into individual letters.
        public static void Phase9()
        {
            int phaseNumber = 9;

            if (Directory.Exists($"{BasePath}\\Phase{phaseNumber}"))
            {
                Directory.Delete($"{BasePath}\\Phase{phaseNumber}", true);
            }
            Directory.CreateDirectory($"{BasePath}\\Phase{phaseNumber}");

            int i = 0;
            string[] files = Directory.GetFiles($"{BasePath}\\Phase{phaseNumber - 1}");
            foreach (string file in files)
            {
                Directory.CreateDirectory($"{BasePath}\\Phase{phaseNumber}\\{i}");

                Bitmap bitmap = new Bitmap(file);

                //Locates all rows containing data and adds a dataRegion for each row.
                List<Range> dataRegions = new List<Range>();

                for (int x = 0; x < bitmap.Width; x++)
                {
                    bool containsData = false;

                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        Color color = bitmap.GetPixel(x, y);

                        if (color.R == 255 && color.G == 255 && color.B == 255)
                        {
                            containsData = true;
                            break;
                        }
                    }

                    if (containsData)
                    {
                        dataRegions.Add(new Range(x, x));
                    }
                }

                //Combines adjacent data rows into larger data groups.
                for (int j = 0; j < dataRegions.Count; j++)
                {
                    if ((j + 1 < dataRegions.Count) && (dataRegions[j].Max + 1) == dataRegions[j + 1].Min)
                    {
                        dataRegions[j].Max = dataRegions[j + 1].Max;
                        dataRegions.RemoveAt(j + 1);
                        j--;
                    }
                }

                //Copy the marked regions into separate images.
                for (int j = 0; j < dataRegions.Count; j++)
                {
                    Bitmap charImg = new Bitmap(dataRegions[j].Max - dataRegions[j].Min + 1, bitmap.Height);

                    Graphics graphics = Graphics.FromImage(charImg);
                    graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                    graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

                    graphics.DrawImage(bitmap, new Rectangle(0, 0, charImg.Width, charImg.Height), new Rectangle(dataRegions[j].Min, 0, charImg.Width, charImg.Height), GraphicsUnit.Pixel);

                    charImg.Save($"{BasePath}\\Phase{phaseNumber}\\{i}\\{j}.png", ImageFormat.Png);

                    charImg.Dispose();
                    graphics.Dispose();
                }

                bitmap.Dispose();

                Console.WriteLine($"Phase{phaseNumber} - Exported Chars From Image - {i} of {files.Length}");
                i++;
            }
        }
        //Converts all images back to PNG.
        public static void Phase8()
        {
            int phaseNumber = 8;

            if (Directory.Exists($"{BasePath}\\Phase{phaseNumber}"))
            {
                Directory.Delete($"{BasePath}\\Phase{phaseNumber}", true);
            }
            Directory.CreateDirectory($"{BasePath}\\Phase{phaseNumber}");

            int i = 0;
            string[] files = Directory.GetFiles($"{BasePath}\\Phase{phaseNumber - 1}");
            foreach (string file in files)
            {
                Bitmap bitmap = new Bitmap(file);

                bitmap.Save($"{BasePath}\\Phase{phaseNumber}\\{i}.png", ImageFormat.Png);

                bitmap.Dispose();

                Console.WriteLine($"Phase{phaseNumber} - Converted Image - {i} of {files.Length}");
                i++;
            }
        }
        public sealed class Range
        {
            public int Min = 0;
            public int Max = 0;
            private Range()
            {
                Min = 0;
                Max = 0;
            }
            public Range(int min, int max)
            {
                Min = min;
                Max = max;
            }

            public override string ToString()
            {
                return $"Range({Min}, {Max})";
            }
        }
        //Format and prepare the minecraft font.
        public static void GenerateFont()
        {
            //Delete font related files and folder.
            if (File.Exists($"{BasePath}\\Font1.png"))
            {
                File.Delete($"{BasePath}\\Font1.png");
            }

            if (File.Exists($"{BasePath}\\Font2.png"))
            {
                File.Delete($"{BasePath}\\Font2.png");
            }

            if (File.Exists($"{BasePath}\\Font3.png"))
            {
                File.Delete($"{BasePath}\\Font3.png");
            }

            if (Directory.Exists($"{BasePath}\\Font"))
            {
                Directory.Delete($"{BasePath}\\Font", true);
            }
            Directory.CreateDirectory($"{BasePath}\\Font");

            //Crop chat out of full screenshot.
            Bitmap font0 = new Bitmap($"{BasePath}\\Font0.png");
            Bitmap font1 = new Bitmap(Font1Size.X, Font1Size.Y);

            Graphics graphics1 = Graphics.FromImage(font1);
            graphics1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            graphics1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

            graphics1.DrawImage(font0, Font1Rect, Font1CropRect, GraphicsUnit.Pixel);

            font1.Save($"{BasePath}\\Font1.png", ImageFormat.Png);

            font0.Dispose();
            graphics1.Dispose();

            //Resize font to 1/4 of its original size.
            Bitmap font2 = new Bitmap(Font2Size.X, Font2Size.Y);

            Graphics graphics2 = Graphics.FromImage(font2);
            graphics2.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            graphics2.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

            graphics2.DrawImage(font1, Font2Rect, Font1Rect, GraphicsUnit.Pixel);

            font2.Save($"{BasePath}\\Font2.png", ImageFormat.Png);

            font1.Dispose();
            graphics2.Dispose();

            //Round all pixels to black or white.
            font2.Dispose();

            Bitmap font3 = new Bitmap($"{BasePath}\\Font2.png");

            for (int x = 0; x < font3.Width; x++)
            {
                for (int y = 0; y < font3.Height; y++)
                {
                    Color color = font3.GetPixel(x, y);

                    if (color.R == 221 && color.G == 221 && color.B == 221)
                    {
                        font3.SetPixel(x, y, Color.White);
                    }
                    else if (color.R == 55 && color.G == 55 && color.B == 55)
                    {
                        font3.SetPixel(x, y, Color.Black);
                    }
                    else if (color.R == 0 && color.G == 0 && color.B == 0)
                    {

                    }
                    else
                    {
                        throw new Exception("Inavlid pixel color.");
                    }
                }
            }

            font3.Save($"{BasePath}\\Font3.png", ImageFormat.Png);

            //Locates all rows containing data and adds a dataRegion for each row.
            List<Range> dataRegions = new List<Range>();

            for (int x = 0; x < font3.Width; x++)
            {
                bool containsData = false;

                for (int y = 0; y < font3.Height; y++)
                {
                    Color color = font3.GetPixel(x, y);

                    if (color.R == 255 && color.G == 255 && color.B == 255)
                    {
                        containsData = true;
                        break;
                    }
                }

                if (containsData)
                {
                    dataRegions.Add(new Range(x, x));
                }
            }

            //Combines adjacent data rows into larger data groups.
            for (int i = 0; i < dataRegions.Count; i++)
            {
                if ((i + 1 < dataRegions.Count) && (dataRegions[i].Max + 1) == dataRegions[i + 1].Min)
                {
                    dataRegions[i].Max = dataRegions[i + 1].Max;
                    dataRegions.RemoveAt(i + 1);
                    i--;
                }
            }

            //Copy the marked regions into separate images and save as the associated char.
            string charset = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789:_";
            for (int i = 0; i < charset.Length; i++)
            {
                Bitmap charImg = new Bitmap(dataRegions[i].Max - dataRegions[i].Min + 1, font3.Height);

                Graphics graphics = Graphics.FromImage(charImg);
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

                graphics.DrawImage(font3, new Rectangle(0, 0, charImg.Width, charImg.Height), new Rectangle(dataRegions[i].Min, 0, charImg.Width, charImg.Height), GraphicsUnit.Pixel);

                if (char.IsUpper(charset[i]))
                {
                    charImg.Save($"{BasePath}\\Font\\Upper_{charset[i]}.png", ImageFormat.Png);
                }
                else if (char.IsLower(charset[i]))
                {
                    charImg.Save($"{BasePath}\\Font\\Lower_{charset[i]}.png", ImageFormat.Png);
                }
                else if (char.IsDigit(charset[i]))
                {
                    charImg.Save($"{BasePath}\\Font\\Number_{charset[i]}.png", ImageFormat.Png);
                }
                else if (charset[i] == ':')
                {
                    charImg.Save($"{BasePath}\\Font\\Colon.png", ImageFormat.Png);
                }
                else if (charset[i] == '_')
                {
                    charImg.Save($"{BasePath}\\Font\\Underscore.png", ImageFormat.Png);
                }

                charImg.Dispose();
                graphics.Dispose();
            }
        }
        //Checkes images for duplicates. (This can take awhile)
        public static void Phase7()
        {
            int phaseNumber = 7;

            if (Directory.Exists($"{BasePath}\\Phase{phaseNumber}"))
            {
                Directory.Delete($"{BasePath}\\Phase{phaseNumber}", true);
            }
            Directory.CreateDirectory($"{BasePath}\\Phase{phaseNumber}");

            int l = 0;
            string[] files = Directory.GetFiles($"{BasePath}\\Phase{phaseNumber - 1}");
            foreach (string file in files)
            {
                File.Copy(file, $"{BasePath}\\Phase{phaseNumber}\\{l}.bmp");

                Console.WriteLine($"Phase{phaseNumber} - Copied Image - {l} of {files.Length}");
                l++;
            }

            List<string> fileDatabase = new List<string>(Directory.GetFiles($"{BasePath}\\Phase{phaseNumber}"));
            for (int i = 0; i < fileDatabase.Count; i++)
            {
                int dupcount = 0;

                string file1 = fileDatabase[i];
                int length1 = (int)new FileInfo(file1).Length;
                byte[] stream1 = File.ReadAllBytes(file1);

                for (int j = i + 1; j < fileDatabase.Count; j++)
                {
                    string file2 = fileDatabase[j];
                    int length2 = (int)new FileInfo(file2).Length;

                    if (length1 != length2)
                    {
                        continue;
                    }

                    byte[] stream2 = File.ReadAllBytes(file2);

                    bool difByteFound = false;
                    for (int k = 0; k < stream1.Length; k++)
                    {
                        if (stream1[k] != stream2[k])
                        {
                            difByteFound = true;
                            break;
                        }
                    }

                    if (difByteFound)
                    {
                        continue;
                    }

                    File.Delete(file2);

                    dupcount++;

                    fileDatabase.RemoveAt(j);
                    j--;
                }

                Console.WriteLine($"Phase{phaseNumber} - Checked Image For Duplicates - There were {dupcount} - {i} of {fileDatabase.Count}");
            }
        }
        //Converts all Images to BMP.
        public static void Phase6()
        {
            int phaseNumber = 6;

            if (Directory.Exists($"{BasePath}\\Phase{phaseNumber}"))
            {
                Directory.Delete($"{BasePath}\\Phase{phaseNumber}", true);
            }
            Directory.CreateDirectory($"{BasePath}\\Phase{phaseNumber}");

            int i = 0;
            string[] files = Directory.GetFiles($"{BasePath}\\Phase{phaseNumber - 1}");
            foreach (string file in files)
            {
                Bitmap source = new Bitmap(file);

                Bitmap destination = new Bitmap(source.Width, source.Height);

                for (int x = 0; x < source.Width; x++)
                {
                    for (int y = 0; y < source.Height; y++)
                    {
                        Color color = source.GetPixel(x, y);

                        destination.SetPixel(x, y, Color.FromArgb(255, color.R, color.G, color.B));
                    }
                }

                destination.Save($"{BasePath}\\Phase{phaseNumber}\\{i}.bmp", ImageFormat.Bmp);
                source.Dispose();
                destination.Dispose();

                Console.WriteLine($"Phase{phaseNumber} - Converted Image To BMP - {i} of {files.Length}");
                i++;
            }
        }
        //Extracts the 10 item names into separate files.
        public static void Phase5()
        {
            int phaseNumber = 5;

            if (Directory.Exists($"{BasePath}\\Phase{phaseNumber}"))
            {
                Directory.Delete($"{BasePath}\\Phase{phaseNumber}", true);
            }
            Directory.CreateDirectory($"{BasePath}\\Phase{phaseNumber}");

            int i = 0;
            string[] files = Directory.GetFiles($"{BasePath}\\Phase{phaseNumber - 1}");
            foreach (string file in files)
            {
                Bitmap source = new Bitmap(file);

                for (int j = 0; j < 10; j++)
                {
                    Bitmap destination = new Bitmap(Phase5Size.X, Phase5Size.Y);

                    Graphics graphics = Graphics.FromImage(destination);
                    graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                    graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

                    graphics.DrawImage(source, Phase5Rect, new Rectangle(0, 12 * j, Phase5Size.X, Phase5Size.Y), GraphicsUnit.Pixel);

                    destination.Save($"{BasePath}\\Phase{phaseNumber}\\{i} {j}.png", ImageFormat.Png);

                    graphics.Dispose();
                    destination.Dispose();
                }

                source.Dispose();

                Console.WriteLine($"Phase{phaseNumber} - Extracted Individual Words From Image - {i} of {files.Length}");
                i++;
            }
        }
        //Sharpens each image by rounding all pixel to black or white.
        public static void Phase4()
        {
            int phaseNumber = 4;

            if (Directory.Exists($"{BasePath}\\Phase{phaseNumber}"))
            {
                Directory.Delete($"{BasePath}\\Phase{phaseNumber}", true);
            }
            Directory.CreateDirectory($"{BasePath}\\Phase{phaseNumber}");

            int i = 0;
            string[] files = Directory.GetFiles($"{BasePath}\\Phase{phaseNumber - 1}");
            foreach (string file in files)
            {
                Bitmap source = new Bitmap(file);

                for (int x = 0; x < Phase4Size.X; x++)
                {
                    for (int y = 0; y < Phase4Size.Y; y++)
                    {
                        Color color = source.GetPixel(x, y);

                        if (color.R == 252 && color.G == 252 && color.B == 0)
                        {
                            source.SetPixel(x, y, Color.White);
                        }
                        else if (color.R == 168 && color.G == 168 && color.B == 168)
                        {
                            source.SetPixel(x, y, Color.White);
                        }
                        else if (color.R == 41 && color.G == 41 && color.B == 41)
                        {
                            source.SetPixel(x, y, Color.Black);
                        }
                        else if (color.R == 62 && color.G == 62 && color.B == 0)
                        {
                            source.SetPixel(x, y, Color.Black);
                        }
                        else if (color.R == 0 && color.G == 0 && color.B == 0)
                        {

                        }
                        else
                        {
                            throw new Exception("Inavlid pixel color.");
                        }
                    }
                }

                source.Save($"{BasePath}\\Phase{phaseNumber}\\{i}.png", ImageFormat.Png);
                source.Dispose();

                Console.WriteLine($"Phase{phaseNumber} - Made Image Monochrome - {i} of {files.Length}");
                i++;
            }
        }
        //Resizes images to 1/4th of their original size. 
        public static void Phase3()
        {
            int phaseNumber = 3;

            if (Directory.Exists($"{BasePath}\\Phase{phaseNumber}"))
            {
                Directory.Delete($"{BasePath}\\Phase{phaseNumber}", true);
            }
            Directory.CreateDirectory($"{BasePath}\\Phase{phaseNumber}");

            int i = 0;
            string[] files = Directory.GetFiles($"{BasePath}\\Phase{phaseNumber - 1}");
            foreach (string file in files)
            {
                Bitmap source = new Bitmap(file);
                Bitmap destination = new Bitmap(Phase3Size.X, Phase3Size.Y);

                Graphics graphics = Graphics.FromImage(destination);
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

                graphics.DrawImage(source, Phase3Rect, Phase2Rect, GraphicsUnit.Pixel);

                destination.Save($"{BasePath}\\Phase{phaseNumber}\\{i}.png", ImageFormat.Png);

                source.Dispose();
                graphics.Dispose();
                destination.Dispose();

                Console.WriteLine($"Phase{phaseNumber} - Shrunk Image - {i} of {files.Length}");
                i++;
            }
        }
        //Crops the correct portion of the screenshots out of the larger image. 
        public static void Phase2()
        {
            int phaseNumber = 2;

            if (Directory.Exists($"{BasePath}\\Phase{phaseNumber}"))
            {
                Directory.Delete($"{BasePath}\\Phase{phaseNumber}", true);
            }
            Directory.CreateDirectory($"{BasePath}\\Phase{phaseNumber}");

            int i = 0;
            string[] files = Directory.GetFiles($"{BasePath}\\Phase{phaseNumber - 1}");
            foreach (string file in files)
            {
                Bitmap source = new Bitmap(file);
                Bitmap destination = new Bitmap(Phase2Size.X, Phase2Size.Y);

                Graphics graphics = Graphics.FromImage(destination);
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

                graphics.DrawImage(source, Phase2Rect, Phase2CropRect, GraphicsUnit.Pixel);

                destination.Save($"{BasePath}\\Phase{phaseNumber}\\{i}.png", ImageFormat.Png);

                source.Dispose();
                graphics.Dispose();
                destination.Dispose();

                Console.WriteLine($"Phase{phaseNumber} - Cropped File - {i} of {files.Length}");
                i++;
            }
        }
        //Renames the images to 0 based indexes.
        public static void Phase1()
        {
            int phaseNumber = 1;

            if (Directory.Exists($"{BasePath}\\Phase{phaseNumber}"))
            {
                Directory.Delete($"{BasePath}\\Phase{phaseNumber}", true);
            }
            Directory.CreateDirectory($"{BasePath}\\Phase{phaseNumber}");

            int i = 0;
            string[] files = Directory.GetFiles($"{BasePath}\\Phase{phaseNumber - 1}");
            foreach (string file in files)
            {
                File.Copy(file, $"{BasePath}\\Phase{phaseNumber}\\{i}{Path.GetExtension(file)}");

                Console.WriteLine($"Phase{phaseNumber} - Renamed File - {i} of {files.Length}");
                i++;
            }
        }
    }
}