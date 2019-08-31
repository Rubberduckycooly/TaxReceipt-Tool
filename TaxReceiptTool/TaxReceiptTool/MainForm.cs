using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace TaxReceiptTool
{
    public partial class MainForm : Form
    {

        public RSDKv1.Script Script;
        public string name;

        public string datafolderpath;
        public List<string> scriptnames = new List<string>();
        public List<string> dirnames = new List<string>();
        public List<RSDKv1.Script> Scripts = new List<RSDKv1.Script>();
        int Value0 = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void OpenScriptButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "TaxReceipt Scripts|*.txt";

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                Script = new RSDKv1.Script(new System.IO.StreamReader(dlg.FileName));
                name = Path.GetFileNameWithoutExtension(dlg.FileName);
            }
        }

        private void ExportToAnimButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "RSDKvRS Animations|*.ani|RSDKv1 Animations|*.ani|RSDKv2 Animations|*.ani|RSDKvB Animations|*.ani|RSDKv5 Animations|*.bin";

            dlg.FileName = name;

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                switch(dlg.FilterIndex-1)
                {
                    case 0:
                        RSDKvRS.Animation animvRS = new RSDKvRS.Animation();
                        List<RSDKvRS.Animation.AnimationEntry> sprAnimvRS = new List<RSDKvRS.Animation.AnimationEntry>();

                        RSDKv1.Script.Sub subvRS = new RSDKv1.Script.Sub();

                        for (int i = 0; i < Script.Subs.Count; i++)
                        {
                            if (Script.Subs[i].Name == "SubObjectStartup")
                            {
                                subvRS = Script.Subs[i];
                                break;
                            }
                        }

                        List<RSDKv1.Script.Sub.Function> LoadSpritesvRS = subvRS.GetFunctionByName("LoadSpriteSheet");

                        for (int i = 0; i < LoadSpritesvRS.Count; i++)
                        {
                            animvRS.SpriteSheets[i] = LoadSpritesvRS[i].Paramaters[0];
                        }

                        List<RSDKv1.Script.Sub.Function> SpriteFramesvRS = subvRS.GetFunctionByName("SpriteFrame");

                        for (byte s = 0; s < LoadSpritesvRS.Count; s++)
                        {
                            RSDKvRS.Animation.AnimationEntry a = new RSDKvRS.Animation.AnimationEntry();
                            for (int i = 0; i < SpriteFramesvRS.Count; i++)
                            {
                                RSDKvRS.Animation.AnimationEntry.Frame Frame = new RSDKvRS.Animation.AnimationEntry.Frame();
                                Frame.PivotX = Convert.ToSByte(SpriteFramesvRS[i].Paramaters[0]);
                                Frame.PivotY = Convert.ToSByte(SpriteFramesvRS[i].Paramaters[1]);
                                Frame.Width = Convert.ToByte(SpriteFramesvRS[i].Paramaters[2]);
                                Frame.Height = Convert.ToByte(SpriteFramesvRS[i].Paramaters[3]);
                                Frame.X = Convert.ToByte(SpriteFramesvRS[i].Paramaters[4]);
                                Frame.Y = Convert.ToByte(SpriteFramesvRS[i].Paramaters[5]);
                                Frame.SpriteSheet = s;
                                a.Frames.Add(Frame);
                            }
                            sprAnimvRS.Add(a);
                        }

                        for (int i = 0; i < sprAnimvRS.Count; i++)
                        {
                            animvRS.Animations.Add(sprAnimvRS[i]);
                        }

                        animvRS.Write(new RSDKvRS.Writer(dlg.FileName));

                        break;
                    case 1:
                        RSDKv1.Animation animv1 = new RSDKv1.Animation();
                        List<RSDKv1.Animation.AnimationEntry> sprAnimv1 = new List<RSDKv1.Animation.AnimationEntry>();

                        RSDKv1.Script.Sub subv1 = new RSDKv1.Script.Sub();

                        for (int i = 0; i < Script.Subs.Count; i++)
                        {
                            if (Script.Subs[i].Name == "SubObjectStartup")
                            {
                                subv1 = Script.Subs[i];
                                break;
                            }
                        }

                        List<RSDKv1.Script.Sub.Function> LoadSpritesv1 = subv1.GetFunctionByName("LoadSpriteSheet");

                        for (int i = 0; i < LoadSpritesv1.Count; i++)
                        {
                            animv1.SpriteSheets[i] = LoadSpritesv1[i].Paramaters[0];
                        }

                        List<RSDKv1.Script.Sub.Function> SpriteFramesv1 = subv1.GetFunctionByName("SpriteFrame");

                        for (byte s = 0; s < LoadSpritesv1.Count; s++)
                        {
                            RSDKv1.Animation.AnimationEntry a = new RSDKv1.Animation.AnimationEntry();
                            for (int i = 0; i < SpriteFramesv1.Count; i++)
                            {
                                RSDKv1.Animation.AnimationEntry.Frame Frame = new RSDKv1.Animation.AnimationEntry.Frame();
                                Frame.PivotX = Convert.ToSByte(SpriteFramesv1[i].Paramaters[0]);
                                Frame.PivotY = Convert.ToSByte(SpriteFramesv1[i].Paramaters[1]);
                                Frame.Width = Convert.ToByte(SpriteFramesv1[i].Paramaters[2]);
                                Frame.Height = Convert.ToByte(SpriteFramesv1[i].Paramaters[3]);
                                Frame.X = Convert.ToByte(SpriteFramesv1[i].Paramaters[4]);
                                Frame.Y = Convert.ToByte(SpriteFramesv1[i].Paramaters[5]);
                                Frame.SpriteSheet = s;
                                a.Frames.Add(Frame);
                            }
                            sprAnimv1.Add(a);
                        }

                        for (int i = 0; i < sprAnimv1.Count; i++)
                        {
                            animv1.Animations.Add(sprAnimv1[i]);
                        }

                        animv1.Write(new RSDKv1.Writer(dlg.FileName));

                        break;
                    case 2:
                        RSDKv2.Animation animv2 = new RSDKv2.Animation();
                        List<RSDKv2.Animation.AnimationEntry> sprAnimv2 = new List<RSDKv2.Animation.AnimationEntry>();

                        RSDKv1.Script.Sub subv2 = new RSDKv1.Script.Sub();

                        for (int i = 0; i < Script.Subs.Count; i++)
                        {
                            if (Script.Subs[i].Name == "SubObjectStartup")
                            {
                                subv2 = Script.Subs[i];
                                break;
                            }
                        }

                        List<RSDKv1.Script.Sub.Function> LoadSpritesv2 = subv2.GetFunctionByName("LoadSpriteSheet");

                        for (int i = 0; i < LoadSpritesv2.Count; i++)
                        {
                            animv2.SpriteSheets.Add(LoadSpritesv2[i].Paramaters[0]);
                        }

                        List<RSDKv1.Script.Sub.Function> SpriteFramesv2 = subv2.GetFunctionByName("SpriteFrame");

                        for (byte s = 0; s < LoadSpritesv2.Count; s++)
                        {
                            RSDKv2.Animation.AnimationEntry a = new RSDKv2.Animation.AnimationEntry();
                            a.AnimName = name + "Animation " + s;
                            for (int i = 0; i < SpriteFramesv2.Count; i++)
                            {
                                int PivotX = Convert.ToInt32(SpriteFramesv2[i].Paramaters[0]);
                                int PivotY = Convert.ToInt32(SpriteFramesv2[i].Paramaters[1]);
                                uint Width = Convert.ToUInt32(SpriteFramesv2[i].Paramaters[2]);
                                uint Height = Convert.ToUInt32(SpriteFramesv2[i].Paramaters[3]);
                                uint X = Convert.ToUInt32(SpriteFramesv2[i].Paramaters[4]);
                                uint Y = Convert.ToUInt32(SpriteFramesv2[i].Paramaters[5]);

                                if (Width > 255) Width = 255;
                                if (Height > 255) Height = 255;
                                if (X > 255) X = 255;
                                if (Y > 255) Y = 255;


                                RSDKv2.Animation.AnimationEntry.Frame Frame = new RSDKv2.Animation.AnimationEntry.Frame();
                                Frame.PivotX = (SByte)PivotX;
                                Frame.PivotY = (SByte)PivotY;
                                Frame.Width = (byte)Width;
                                Frame.Height = (byte)Height;
                                Frame.X = (byte)X;
                                Frame.Y = (byte)Y;
                                a.Frames.Add(Frame);
                            }
                            sprAnimv2.Add(a);
                        }

                        for (int i = 0; i < sprAnimv2.Count; i++)
                        {
                            animv2.Animations.Add(sprAnimv2[i]);
                        }

                        animv2.Write(new RSDKv2.Writer(dlg.FileName));

                        break;
                    case 3:
                        RSDKvB.Animation animvB = new RSDKvB.Animation();
                        List<RSDKvB.Animation.AnimationEntry> sprAnimvB = new List<RSDKvB.Animation.AnimationEntry>();

                        RSDKv1.Script.Sub subvB = new RSDKv1.Script.Sub();

                        for (int i = 0; i < Script.Subs.Count; i++)
                        {
                            if (Script.Subs[i].Name == "SubObjectStartup")
                            {
                                subvB = Script.Subs[i];
                                break;
                            }
                        }

                        List<RSDKv1.Script.Sub.Function> LoadSpritesvB = subvB.GetFunctionByName("LoadSpriteSheet");

                        for (int i = 0; i < LoadSpritesvB.Count; i++)
                        {
                            animvB.SpriteSheets.Add(LoadSpritesvB[i].Paramaters[0]);
                        }

                        List<RSDKv1.Script.Sub.Function> SpriteFramesvB = subvB.GetFunctionByName("SpriteFrame");

                        for (byte s = 0; s < LoadSpritesvB.Count; s++)
                        {
                            RSDKvB.Animation.AnimationEntry a = new RSDKvB.Animation.AnimationEntry();
                            a.AnimName = name + "Animation " + s;
                            for (int i = 0; i < SpriteFramesvB.Count; i++)
                            {
                                RSDKvB.Animation.AnimationEntry.Frame Frame = new RSDKvB.Animation.AnimationEntry.Frame();
                                Frame.PivotX = Convert.ToSByte(SpriteFramesvB[i].Paramaters[0]);
                                Frame.PivotY = Convert.ToSByte(SpriteFramesvB[i].Paramaters[1]);
                                Frame.Width = Convert.ToByte(SpriteFramesvB[i].Paramaters[2]);
                                Frame.Height = Convert.ToByte(SpriteFramesvB[i].Paramaters[3]);
                                Frame.X = Convert.ToByte(SpriteFramesvB[i].Paramaters[4]);
                                Frame.Y = Convert.ToByte(SpriteFramesvB[i].Paramaters[5]);
                                Frame.SpriteSheet = s;
                                a.Frames.Add(Frame);
                            }
                            sprAnimvB.Add(a);
                        }

                        for (int i = 0; i < sprAnimvB.Count; i++)
                        {
                            animvB.Animations.Add(sprAnimvB[i]);
                        }

                        animvB.Write(new RSDKvB.Writer(dlg.FileName));

                        break;
                    case 4:
                        RSDKv5.Animation animv5 = new RSDKv5.Animation();
                        List<RSDKv5.Animation.AnimationEntry> sprAnimv5 = new List<RSDKv5.Animation.AnimationEntry>();

                        RSDKv1.Script.Sub subv5 = new RSDKv1.Script.Sub();

                        for (int i = 0; i < Script.Subs.Count; i++)
                        {
                            if (Script.Subs[i].Name == "SubObjectStartup")
                            {
                                subv5 = Script.Subs[i];
                                break;
                            }
                        }

                        List<RSDKv1.Script.Sub.Function> LoadSpritesv5 = subv5.GetFunctionByName("LoadSpriteSheet");

                        for (int i = 0; i < LoadSpritesv5.Count; i++)
                        {
                            animv5.SpriteSheets.Add(LoadSpritesv5[i].Paramaters[0]);
                        }

                        List<RSDKv1.Script.Sub.Function> SpriteFramesv5 = subv5.GetFunctionByName("SpriteFrame");

                        for (byte s = 0; s < LoadSpritesv5.Count; s++)
                        {
                            RSDKv5.Animation.AnimationEntry a = new RSDKv5.Animation.AnimationEntry();
                            a.AnimName = name + "Animation " + s;
                            for (int i = 0; i < SpriteFramesv5.Count; i++)
                            {
                                RSDKv5.Animation.AnimationEntry.Frame Frame = new RSDKv5.Animation.AnimationEntry.Frame();
                                Frame.PivotX = Convert.ToSByte(SpriteFramesv5[i].Paramaters[0]);
                                Frame.PivotY = Convert.ToSByte(SpriteFramesv5[i].Paramaters[1]);
                                Frame.Width = Convert.ToByte(SpriteFramesv5[i].Paramaters[2]);
                                Frame.Height = Convert.ToByte(SpriteFramesv5[i].Paramaters[3]);
                                Frame.X = Convert.ToByte(SpriteFramesv5[i].Paramaters[4]);
                                Frame.Y = Convert.ToByte(SpriteFramesv5[i].Paramaters[5]);
                                Frame.Delay = 256;
                                Frame.SpriteSheet = s;
                                a.Frames.Add(Frame);
                            }
                            sprAnimv5.Add(a);
                        }

                        for (int i = 0; i < sprAnimv5.Count; i++)
                        {
                            animv5.Animations.Add(sprAnimv5[i]);
                        }

                        animv5.Write(new RSDKv5.Writer(dlg.FileName));

                        break;
                }
            }
        }

        private void OpenDataFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.Description = "Select a data folder!";

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                DirectoryInfo dir = new DirectoryInfo(dlg.SelectedPath + "//Scripts");
                datafolderpath = dlg.SelectedPath;
                LoadDir(dir);
            }
        }

        public void LoadDir(DirectoryInfo dir)
        {

            foreach(FileInfo f in dir.GetFiles())
            {
                if (Path.GetExtension(f.FullName) == ".txt")
                {
                    string file = f.Directory.Name + "//" + Path.GetFileNameWithoutExtension(f.Name);
                    Scripts.Add(new RSDKv1.Script(new System.IO.StreamReader(datafolderpath + "//Scripts//" + file + ".txt")));
                    scriptnames.Add(file);
                }
            }

            foreach (DirectoryInfo d in dir.GetDirectories())
            {
                dirnames.Add(d.Name);
                LoadDir(d);
            }
        }

        private void ExportDataFolderButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "RSDKvRS Animations|*.ani|RSDKv1 Animations|*.ani|RSDKv2 Animations|*.ani|RSDKvB Animations|*.ani|RSDKv5 Animations|*.bin";

            dlg.FileName = name;

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                DirectoryInfo dir = new DirectoryInfo(datafolderpath + "//Animations");

                CreateDirs(dir);
                Value0 = 0;

                for (int i = 0; i < scriptnames.Count; i++)
                {
                    ExportAnim(dlg.FilterIndex - 1);
                }
            }
        }

        public void CreateDirs(DirectoryInfo dir)
        {
            if (Value0 < dirnames.Count)
            {
                DirectoryInfo d = new DirectoryInfo(datafolderpath + "//Animations//" + dirnames[Value0]);
                if (!dir.Exists)
                {
                    dir.Create();
                }
                Value0++;
                CreateDirs(d);
            }
        }

        public void ExportAnim(int Type)
        {
            switch (Type)
            {
                case 0:
                    RSDKvRS.Animation animvRS = new RSDKvRS.Animation();
                    List<RSDKvRS.Animation.AnimationEntry> sprAnimvRS = new List<RSDKvRS.Animation.AnimationEntry>();

                    RSDKv1.Script.Sub subvRS = new RSDKv1.Script.Sub();

                    for (int i = 0; i < Scripts[Value0].Subs.Count; i++)
                    {
                        if (Scripts[Value0].Subs[i].Name == "SubObjectStartup")
                        {
                            subvRS = Scripts[Value0].Subs[i];
                            break;
                        }
                    }

                    List<RSDKv1.Script.Sub.Function> CollisionvRS = subvRS.GetFunctionByName("PlayerObjectCollision");

                    List<RSDKvRS.Animation.AnimationEntry.Frame.HitBox> HitboxesvRS = new List<RSDKvRS.Animation.AnimationEntry.Frame.HitBox>();

                    for (int i = 0; i < CollisionvRS.Count; i++)
                    {
                        string name = CollisionvRS[i].Paramaters[0].Replace("C_", "");
                        sbyte x, y, w, h;
                        x = y = w = h = 0;
                        try
                        {
                            x = sbyte.Parse(CollisionvRS[i].Paramaters[1]);
                            y = sbyte.Parse(CollisionvRS[i].Paramaters[2]);
                            w = sbyte.Parse(CollisionvRS[i].Paramaters[3]);
                            h = sbyte.Parse(CollisionvRS[i].Paramaters[4]);
                        }
                        catch (Exception ex)
                        {

                        }
                        RSDKvRS.Animation.AnimationEntry.Frame.HitBox hb = new RSDKvRS.Animation.AnimationEntry.Frame.HitBox();
                        hb.X = x;
                        hb.Y = y;
                        hb.Width = w;
                        hb.Height = h;
                        HitboxesvRS.Add(hb);
                    }

                    List<RSDKv1.Script.Sub.Function> LoadSpritesvRS = subvRS.GetFunctionByName("LoadSpriteSheet");

                    for (int i = 0; i < LoadSpritesvRS.Count; i++)
                    {
                        animvRS.SpriteSheets[i] = LoadSpritesvRS[i].Paramaters[0];
                    }

                    List<RSDKv1.Script.Sub.Function> SpriteFramesvRS = subvRS.GetFunctionByName("SpriteFrame");

                    for (byte s = 0; s < LoadSpritesvRS.Count; s++)
                    {
                        RSDKvRS.Animation.AnimationEntry a = new RSDKvRS.Animation.AnimationEntry();
                        for (int i = 0; i < SpriteFramesvRS.Count; i++)
                        {
                            RSDKvRS.Animation.AnimationEntry.Frame Frame = new RSDKvRS.Animation.AnimationEntry.Frame();
                            Frame.PivotX = Convert.ToSByte(SpriteFramesvRS[i].Paramaters[0]);
                            Frame.PivotY = Convert.ToSByte(SpriteFramesvRS[i].Paramaters[1]);
                            Frame.Width = Convert.ToByte(SpriteFramesvRS[i].Paramaters[2]);
                            Frame.Height = Convert.ToByte(SpriteFramesvRS[i].Paramaters[3]);
                            Frame.X = Convert.ToByte(SpriteFramesvRS[i].Paramaters[4]);
                            Frame.Y = Convert.ToByte(SpriteFramesvRS[i].Paramaters[5]);
                            Frame.SpriteSheet = s;

                            Frame.CollisionBox.X = HitboxesvRS[0].X;
                            Frame.CollisionBox.Y = HitboxesvRS[0].Y;
                            Frame.CollisionBox.Width = HitboxesvRS[0].Width;
                            Frame.CollisionBox.Height = HitboxesvRS[0].Height;

                            a.Frames.Add(Frame);
                        }
                        sprAnimvRS.Add(a);
                    }

                    for (int i = 0; i < sprAnimvRS.Count; i++)
                    {
                        animvRS.Animations.Add(sprAnimvRS[i]);
                    }

                    string animnamevRS = datafolderpath + "//Animations//" + scriptnames[Value0++] + ".ani";

                    animvRS.Write(new RSDKvRS.Writer(animnamevRS));

                    break;
                case 1:
                    RSDKv1.Animation animv1 = new RSDKv1.Animation();
                    List<RSDKv1.Animation.AnimationEntry> sprAnimv1 = new List<RSDKv1.Animation.AnimationEntry>();

                    RSDKv1.Script.Sub subv1 = new RSDKv1.Script.Sub();

                    for (int i = 0; i < Scripts[Value0].Subs.Count; i++)
                    {
                        if (Scripts[Value0].Subs[i].Name == "SubObjectStartup")
                        {
                            subv1 = Scripts[Value0].Subs[i];
                            break;
                        }
                    }

                    List<RSDKv1.Script.Sub.Function> Collisionv1 = subv1.GetFunctionByName("PlayerObjectCollision");

                    List<RSDKv1.Animation.sprHitbox> Hitboxesv1 = new List<RSDKv1.Animation.sprHitbox>();

                    animv1.CollisionBoxes.Clear();

                    if (Collisionv1.Count <= 0)
                    {
                        RSDKv1.Animation.sprHitbox hb = new RSDKv1.Animation.sprHitbox();
                        hb.Left = 0;
                        hb.Top = 0;
                        hb.Right = 0;
                        hb.Bottom = 0;
                        Hitboxesv1.Add(hb);
                    }

                    for (int i = 0; i < Collisionv1.Count; i++)
                    {
                        string name = Collisionv1[i].Paramaters[0].Replace("C_", "");
                        sbyte x, y, w, h;
                        x = y = w = h = 0;
                        try
                        {
                            x = sbyte.Parse(Collisionv1[i].Paramaters[1]);
                            y = sbyte.Parse(Collisionv1[i].Paramaters[2]);
                            w = sbyte.Parse(Collisionv1[i].Paramaters[3]);
                            h = sbyte.Parse(Collisionv1[i].Paramaters[4]);
                        }
                        catch (Exception ex)
                        {

                        }
                        RSDKv1.Animation.sprHitbox hb = new RSDKv1.Animation.sprHitbox();
                        hb.Top = x;
                        hb.Left = y;
                        hb.Right = w;
                        hb.Bottom = h;
                        animv1.CollisionBoxes.Add(hb);
                    }

                    List<RSDKv1.Script.Sub.Function> LoadSpritesv1 = subv1.GetFunctionByName("LoadSpriteSheet");

                    for (int i = 0; i < LoadSpritesv1.Count; i++)
                    {
                        animv1.SpriteSheets[i] = LoadSpritesv1[i].Paramaters[0];
                    }

                    List<RSDKv1.Script.Sub.Function> SpriteFramesv1 = subv1.GetFunctionByName("SpriteFrame");

                    for (byte s = 0; s < LoadSpritesv1.Count; s++)
                    {
                        RSDKv1.Animation.AnimationEntry a = new RSDKv1.Animation.AnimationEntry();
                        for (int i = 0; i < SpriteFramesv1.Count; i++)
                        {
                            RSDKv1.Animation.AnimationEntry.Frame Frame = new RSDKv1.Animation.AnimationEntry.Frame();
                            Frame.PivotX = 0;
                            Frame.PivotX = 0;
                            Frame.X = 0;
                            Frame.Y = 0;
                            Frame.Width = 0;
                            Frame.Height = 0;
                            try
                            {
                                Frame.PivotX = Convert.ToSByte(SpriteFramesv1[i].Paramaters[0]);
                                Frame.PivotY = Convert.ToSByte(SpriteFramesv1[i].Paramaters[1]);
                                Frame.Width = Convert.ToByte(SpriteFramesv1[i].Paramaters[2]);
                                Frame.Height = Convert.ToByte(SpriteFramesv1[i].Paramaters[3]);
                                Frame.X = Convert.ToByte(SpriteFramesv1[i].Paramaters[4]);
                                Frame.Y = Convert.ToByte(SpriteFramesv1[i].Paramaters[5]);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Fuck!");
                            }
                            Frame.SpriteSheet = s;
                            a.Frames.Add(Frame);
                        }
                        sprAnimv1.Add(a);
                    }

                    for (int i = 0; i < sprAnimv1.Count; i++)
                    {
                        animv1.Animations.Add(sprAnimv1[i]);
                    }

                    string animnamev1 = datafolderpath + "//Animations//" + scriptnames[Value0++] + ".ani";

                    animv1.Write(new RSDKv1.Writer(animnamev1));

                    break;
                case 2:
                    List<RSDKv2.Animation> animv2 = new List<RSDKv2.Animation>();
                    RSDKv2.Animation.AnimationEntry sprAnimv2 = new RSDKv2.Animation.AnimationEntry();

                    RSDKv1.Script.Sub subv2 = new RSDKv1.Script.Sub();

                    for (int i = 0; i < Scripts[Value0].Subs.Count; i++)
                    {
                        if (Scripts[Value0].Subs[i].Name == "SubObjectStartup")
                        {
                            subv2 = Scripts[Value0].Subs[i];
                            break;
                        }
                    }

                    List<RSDKv1.Script.Sub.Function> Collisionv2 = subv2.GetFunctionByName("PlayerObjectCollision");

                    List<RSDKv2.Animation.sprHitbox> Hitboxesv2 = new List<RSDKv2.Animation.sprHitbox>();

                    animv2[0].CollisionBoxes.Clear();

                    if (Collisionv2.Count <= 0)
                    {
                        RSDKv2.Animation.sprHitbox hb = new RSDKv2.Animation.sprHitbox();
                        hb.Left = 0;
                        hb.Top = 0;
                        hb.Right = 0;
                        hb.Bottom = 0;
                        Hitboxesv2.Add(hb);
                    }

                    for (int i = 0; i < Collisionv2.Count; i++)
                    {
                        string name = Collisionv2[i].Paramaters[0].Replace("C_", "");
                        sbyte x, y, w, h;
                        x = y = w = h = 0;
                        try
                        {
                            x = sbyte.Parse(Collisionv2[i].Paramaters[1]);
                            y = sbyte.Parse(Collisionv2[i].Paramaters[2]);
                            w = sbyte.Parse(Collisionv2[i].Paramaters[3]);
                            h = sbyte.Parse(Collisionv2[i].Paramaters[4]);
                        }
                        catch (Exception ex)
                        {

                        }
                        RSDKv2.Animation.sprHitbox hb = new RSDKv2.Animation.sprHitbox();
                        hb.Top = x;
                        hb.Left = y;
                        hb.Right = w;
                        hb.Bottom = h;
                        for (int c = 0; c < animv2.Count; c++)
                        {
                            animv2[c].CollisionBoxes.Add(hb);
                        }
                    }

                    List<RSDKv1.Script.Sub.Function> LoadSpritesv2 = subv2.GetFunctionByName("LoadSpriteSheet");

                    if (LoadSpritesv2.Count <= 0)
                    {
                        Value0++;
                        break;
                    }

                    for (int i = 0; i < LoadSpritesv2.Count; i++)
                    {
                        animv2.Add(new RSDKv2.Animation());
                        animv2[i].SpriteSheets.Add(LoadSpritesv2[i].Paramaters[0]);
                    }

                    List<RSDKv1.Script.Sub.Function> SpriteFramesv2 = subv2.GetFunctionByName("SpriteFrame");

                    if (SpriteFramesv2.Count <= 0)
                    {
                        Value0++;
                        break;
                    }

                    for (byte s = 0; s < LoadSpritesv2.Count; s++)
                    {

                        RSDKv2.Animation.AnimationEntry a = new RSDKv2.Animation.AnimationEntry();
                        if (s == 0) a.AnimName = name + " Animation";
                        else if (s > 0) a.AnimName = name + "Animation " + s;
                        for (int i = 0; i < SpriteFramesv2.Count; i++)
                        {
                            RSDKv2.Animation.AnimationEntry.Frame Frame = new RSDKv2.Animation.AnimationEntry.Frame();
                            Frame.PivotX = 0;
                            Frame.PivotX = 0;
                            Frame.X = 0;
                            Frame.Y = 0;
                            Frame.Width = 0;
                            Frame.Height = 0;
                            try
                            {
                                Frame.PivotX = Convert.ToSByte(SpriteFramesv2[i].Paramaters[0]);
                                Frame.PivotY = Convert.ToSByte(SpriteFramesv2[i].Paramaters[1]);
                                Frame.Width = Convert.ToByte(SpriteFramesv2[i].Paramaters[2]);
                                Frame.Height = Convert.ToByte(SpriteFramesv2[i].Paramaters[3]);
                                Frame.X = Convert.ToByte(SpriteFramesv2[i].Paramaters[4]);
                                Frame.Y = Convert.ToByte(SpriteFramesv2[i].Paramaters[5]);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Fuck!");
                            }
                            a.Frames.Add(Frame);
                        }
                        animv2[s].Animations.Add(a);
                    }

                    string animnamev2 = datafolderpath + "//Animations//" + scriptnames[Value0++];

                    for (int i = 0; i < animv2.Count; i++)
                    {
                        if (i == 0) animv2[i].Write(new RSDKv2.Writer(animnamev2 + ".ani"));
                        if (i > 0) animv2[i].Write(new RSDKv2.Writer(animnamev2 + (i+1) + ".ani"));
                    }

                    break;
                case 3:
                    RSDKvB.Animation animvB = new RSDKvB.Animation();
                    List<RSDKvB.Animation.AnimationEntry> sprAnimvB = new List<RSDKvB.Animation.AnimationEntry>();

                    RSDKv1.Script.Sub subvB = new RSDKv1.Script.Sub();

                    for (int i = 0; i < Scripts[Value0].Subs.Count; i++)
                    {
                        if (Scripts[Value0].Subs[i].Name == "SubObjectStartup")
                        {
                            subvB = Scripts[Value0].Subs[i];
                            break;
                        }
                    }

                    List<RSDKv1.Script.Sub.Function> CollisionvB = subvB.GetFunctionByName("PlayerObjectCollision");

                    List<RSDKvB.Animation.sprHitbox> HitboxesvB = new List<RSDKvB.Animation.sprHitbox>();

                    animvB.CollisionBoxes.Clear();

                    if (CollisionvB.Count <= 0)
                    {
                        RSDKvB.Animation.sprHitbox hb = new RSDKvB.Animation.sprHitbox();
                        hb.Left = 0;
                        hb.Top = 0;
                        hb.Right = 0;
                        hb.Bottom = 0;
                        HitboxesvB.Add(hb);
                    }

                    for (int i = 0; i < CollisionvB.Count; i++)
                    {
                        string name = CollisionvB[i].Paramaters[0].Replace("C_", "");
                        sbyte x, y, w, h;
                        x = y = w = h = 0;
                        try
                        {
                            x = sbyte.Parse(CollisionvB[i].Paramaters[1]);
                            y = sbyte.Parse(CollisionvB[i].Paramaters[2]);
                            w = sbyte.Parse(CollisionvB[i].Paramaters[3]);
                            h = sbyte.Parse(CollisionvB[i].Paramaters[4]);
                        }
                        catch (Exception ex)
                        {

                        }
                        RSDKvB.Animation.sprHitbox hb = new RSDKvB.Animation.sprHitbox();
                        hb.Top = x;
                        hb.Left = y;
                        hb.Right = w;
                        hb.Bottom = h;
                        //for (int c = 0; c < animvB.Count; c++)
                        //{
                            animvB.CollisionBoxes.Add(hb);
                        //}
                    }

                    List<RSDKv1.Script.Sub.Function> LoadSpritesvB = subvB.GetFunctionByName("LoadSpriteSheet");

                    for (int i = 0; i < LoadSpritesvB.Count; i++)
                    {
                        animvB.SpriteSheets.Add(LoadSpritesvB[i].Paramaters[0]);
                    }

                    List<RSDKv1.Script.Sub.Function> SpriteFramesvB = subvB.GetFunctionByName("SpriteFrame");

                    for (byte s = 0; s < LoadSpritesvB.Count; s++)
                    {
                        RSDKvB.Animation.AnimationEntry a = new RSDKvB.Animation.AnimationEntry();
                        a.AnimName = name + "Animation " + s;
                        for (int i = 0; i < SpriteFramesvB.Count; i++)
                        {
                            RSDKvB.Animation.AnimationEntry.Frame Frame = new RSDKvB.Animation.AnimationEntry.Frame();
                            Frame.PivotX = 0;
                            Frame.PivotX = 0;
                            Frame.X = 0;
                            Frame.Y = 0;
                            Frame.Width = 0;
                            Frame.Height = 0;
                            try
                            {
                                Frame.PivotX = Convert.ToSByte(SpriteFramesvB[i].Paramaters[0]);
                                Frame.PivotY = Convert.ToSByte(SpriteFramesvB[i].Paramaters[1]);
                                Frame.Width = Convert.ToByte(SpriteFramesvB[i].Paramaters[2]);
                                Frame.Height = Convert.ToByte(SpriteFramesvB[i].Paramaters[3]);
                                Frame.X = Convert.ToByte(SpriteFramesvB[i].Paramaters[4]);
                                Frame.Y = Convert.ToByte(SpriteFramesvB[i].Paramaters[5]);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Fuck!");
                            }
                            Frame.SpriteSheet = s;
                            a.Frames.Add(Frame);
                        }
                        sprAnimvB.Add(a);
                    }

                    for (int i = 0; i < sprAnimvB.Count; i++)
                    {
                        animvB.Animations.Add(sprAnimvB[i]);
                    }

                    string animnamevb = datafolderpath + "//Animations//" + scriptnames[Value0++] + ".ani";

                    animvB.Write(new RSDKvB.Writer(animnamevb));

                    break;
                case 4:
                    RSDKv5.Animation animv5 = new RSDKv5.Animation();
                    List<RSDKv5.Animation.AnimationEntry> sprAnimv5 = new List<RSDKv5.Animation.AnimationEntry>();

                    RSDKv1.Script.Sub subv5 = new RSDKv1.Script.Sub();

                    for (int i = 0; i < Scripts[Value0].Subs.Count; i++)
                    {
                        if (Scripts[Value0].Subs[i].Name == "SubObjectStartup")
                        {
                            subv5 = Scripts[Value0].Subs[i];
                            break;
                        }
                    }

                    List<RSDKv1.Script.Sub.Function> Collisionv5 = subv5.GetFunctionByName("PlayerObjectCollision");

                    for (int i = 0; i < Scripts[Value0].Subs.Count; i++)
                    {
                        List<RSDKv1.Script.Sub.Function> cb = Scripts[Value0].Subs[i].GetFunctionByName("PlayerObjectCollision");
                        for (int ii = 0; ii < cb.Count; ii++)
                        {
                            Collisionv5.Add(cb[ii]);
                        }
                    }

                    List<RSDKv5.Animation.AnimationEntry.Frame.HitBox> Hitboxesv5 = new List<RSDKv5.Animation.AnimationEntry.Frame.HitBox>();

                    animv5.CollisionBoxes.Clear();

                    for (int i = 0; i < Collisionv5.Count; i++)
                    {
                        string name = Collisionv5[i].Paramaters[0].Replace("C_", "");
                        short x, y, w, h;
                        x = y = w = h = 0;
                        try
                        {
                            if (Collisionv5[i].Paramaters.Count > 5)
                            {
                                x = short.Parse(Collisionv5[i].Paramaters[2]);
                                y = short.Parse(Collisionv5[i].Paramaters[3]);
                                w = short.Parse(Collisionv5[i].Paramaters[4]);
                                h = short.Parse(Collisionv5[i].Paramaters[5]);
                            }
                            else
                            {
                                x = short.Parse(Collisionv5[i].Paramaters[1]);
                                y = short.Parse(Collisionv5[i].Paramaters[2]);
                                w = short.Parse(Collisionv5[i].Paramaters[3]);
                                h = short.Parse(Collisionv5[i].Paramaters[4]);
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                        RSDKv5.Animation.AnimationEntry.Frame.HitBox hb = new RSDKv5.Animation.AnimationEntry.Frame.HitBox();
                        hb.X = x;
                        hb.Y = y;
                        hb.Width = w;
                        hb.Height = h;
                        Hitboxesv5.Add(hb);
                        if (animv5.CollisionBoxes.Contains(name)) name += " " + (i + 1);
                        animv5.CollisionBoxes.Add(name);
                    }

                    List<RSDKv1.Script.Sub.Function> LoadSpritesv5 = subv5.GetFunctionByName("LoadSpriteSheet");

                    for (int i = 0; i < LoadSpritesv5.Count; i++)
                    {
                        animv5.SpriteSheets.Add(LoadSpritesv5[i].Paramaters[0]);
                    }

                    List<RSDKv1.Script.Sub.Function> SpriteFramesv5 = subv5.GetFunctionByName("SpriteFrame");

                    for (byte s = 0; s < LoadSpritesv5.Count; s++)
                    {
                        RSDKv5.Animation.AnimationEntry a = new RSDKv5.Animation.AnimationEntry();
                        switch(s)
                        {
                            case 0:
                                //a.AnimName = name + "Main";
                                a.AnimName = Path.GetFileNameWithoutExtension(scriptnames[Value0]).Replace(" ", "");
                                break;
                            default:
                                a.AnimName = name + "Animation " + (s + 1);
                                break;
                        }
                        for (int i = 0; i < SpriteFramesv5.Count; i++)
                        {
                            RSDKv5.Animation.AnimationEntry.Frame Frame = new RSDKv5.Animation.AnimationEntry.Frame();
                            Frame.PivotX = 0;
                            Frame.PivotX = 0;
                            Frame.X = 0;
                            Frame.Y = 0;
                            Frame.Width = 0;
                            Frame.Height = 0;
                            try
                            {
                                Frame.PivotX = Convert.ToInt16(SpriteFramesv5[i].Paramaters[0]);
                                Frame.PivotY = Convert.ToInt16(SpriteFramesv5[i].Paramaters[1]);
                                Frame.Width = Convert.ToInt16(SpriteFramesv5[i].Paramaters[2]);
                                Frame.Height = Convert.ToInt16(SpriteFramesv5[i].Paramaters[3]);
                                Frame.X = Convert.ToInt16(SpriteFramesv5[i].Paramaters[4]);
                                Frame.Y = Convert.ToInt16(SpriteFramesv5[i].Paramaters[5]);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Fuck!");
                            }
                            Frame.Delay = 256;
                            Frame.SpriteSheet = s;
                            Frame.HitBoxes = Hitboxesv5;
                            a.Frames.Add(Frame);
                        }
                        sprAnimv5.Add(a);
                    }

                    for (int i = 0; i < sprAnimv5.Count; i++)
                    {
                        animv5.Animations.Add(sprAnimv5[i]);
                    }

                    string animnamev5 = datafolderpath + "//Animations//" + scriptnames[Value0++] + ".bin";

                    //if it doesn't have any info don't create it
                    if (animv5.Animations.Count > 0 || animv5.CollisionBoxes.Count > 0 || animv5.SpriteSheets.Count > 0)
                    {
                        animv5.Write(new RSDKv5.Writer(animnamev5));
                    }

                    break;
            }
        }
    }
}
