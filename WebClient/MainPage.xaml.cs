using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace WebClient
{
    public class Matric
    { 
        public int shirina;
        public int vysota;
        public int SIZE_MAX=4;
        public float[,] data;
        public Matric()
        {
	        data = new float[4,4];
            shirina=SIZE_MAX;vysota=SIZE_MAX;
	        for(int i=0;i<SIZE_MAX;i++)
		        for(int j=0;j<SIZE_MAX;j++)	data[i,j]=0;
        }
        public Matric(int sh, int vys)
        {
            data = new float[4, 4];
            shirina=sh;
	        vysota=vys;
	        for(int i=0;i<SIZE_MAX;i++)
		        for(int j=0;j<SIZE_MAX;j++)
			        data[i,j]=0;
        }
        public Matric(int sh, int vys, float[,] values)
        {
            data = new float[4, 4];
            shirina=sh;	vysota=vys;
            for(int i=0;i<shirina;i++)
                for(int j=0;j<vysota;j++)
                    data[i,j]=values[i,j];
        }
        public void   SetData(int x,int y,float value){ 	data[x,y]=value;  }
        public float GetData(int x,int y){return data[x,y];}
        public Matric multiply(Matric mat2)
        {
            Matric mat3 = new Matric(mat2.shirina,vysota);
            for(int y=0;y<vysota;y++)
            for(int i=0;i<mat2.shirina;i++)
            for(int j=0;j<shirina;j++)
            {   
                mat3.data[y,i] += data[y,j]*mat2.data[j,i]; 
            } 
            return mat3;
        }
        public Matric minus(Matric m2)
        {
            Matric sub = new Matric(3,3);

            for (int i=0; i<SIZE_MAX; i++)
                for (int j=0; j<SIZE_MAX; j++)
                    sub.data[i,j] = data[i,j] - m2.data[i,j];
            return sub;
        }
    }
    
    public class Point
    {
        private float x, y, z;
        public Point(){x=0;y=0;z=0;}
        public Point(float x1, float y1, float z1){x=x1;y=y1;z=z1;}
        public void setx(float x1){x=x1;}
        public void sety(float y1){y=y1;}
        public void setz(float z1){z=z1;}
        public float getx(){return x;}
        public float gety(){return y;}
        public float getz(){return z;}
        public Point umnog(Matric m)
        {
            Matric res = new Matric(4,1);
            Matric mt = new Matric(4,1);
            mt.SetData(0,0,x);
            mt.SetData(0,1,y);
            mt.SetData(0,2,z);
            mt.SetData(0,3,1);

            res = mt.multiply(m);
            Point q = new Point();
            if (res.GetData(0,3) != 0)
            {       
                q.setx((float)res.GetData(0,0)/(float)res.GetData(0, 3));
	            q.sety((float)res.GetData(0,1)/(float)res.GetData(0, 3));
	            q.setz((float)res.GetData(0,2)/(float)res.GetData(0, 3));
            }
            else  {
                    q.setx(res.GetData(0,0));
                    q.sety(res.GetData(0,1));
                    q.setz(res.GetData(0,2));
                  }
            return q;
        }
    }

    public class Point2
    {
        private float x, y;
        public Point2(){x=0;y=0;}
        public Point2(float x1, float y1) { x = x1; y = y1; }
        public void setx(float x1) { x = x1; }
        public void sety(float y1) { y = y1; }
        public float getx() { return x; }
        public float gety() { return y; }
    }

    

    public partial class MainPage : UserControl
    {
        //string cx, cy, cz;
        //string width, height;
        float sinX, cosX, cosZ, sinZ;
        //int ot;

        Point2 O = new Point2();
        Point X0 = new Point();
        Point X1 = new Point();
        Point Y0 = new Point();
        Point Y1 = new Point();
        Point Z0 = new Point();
        Point Z1 = new Point();
        Point T = new Point();
        Point C = new Point();
        Point T1 = new Point(); 
        Point T2 = new Point(); 
        Point T3 = new Point(); 
        Point TX = new Point(); 
        Point TY = new Point();
        Point TZ = new Point();

        Point X0c = new Point();
        Point X1c = new Point();
        Point Z0c = new Point();
        Point Z1c = new Point();

        
        Point T1c = new Point();
        Point T2c = new Point();
        Point T3c = new Point();
        Point TXc = new Point();
        Point TYc = new Point();
        Point TZc = new Point();

        Point C1c = new Point();
        Point C2c = new Point();
        Point C3c = new Point();
        Point2 Oc = new Point2();

       
        int len = 100;

        public void change()
        {
            int width = Convert.ToInt32(canvas1.Width);   //= w.ToString();
            int height = Convert.ToInt32(canvas1.Height); //h = h.ToString();
            O.setx(width / 2);
            O.sety(height / 2);

            

            int cx = Convert.ToInt32(slider1.Value);//rx.ToString();
            int cy = Convert.ToInt32(slider2.Value);// ry.ToString();
            int cz = Convert.ToInt32(slider3.Value);//  = rz.ToString();

            label1.Content = "X = " + cx;
            label2.Content = "Y = " + cy;
            label3.Content = "Z = " + cz;

            Point C = new Point(cx, cy, cz);

            int tx = Convert.ToInt32(slider4.Value);//rx.ToString();
            int ty = Convert.ToInt32(slider5.Value);// ry.ToString();
            int tz = Convert.ToInt32(slider6.Value);//  = rz.ToString();

            label4.Content = "X = " + tx;
            label5.Content = "Y = " + ty;
            label6.Content = "Z = " + tz;

            Point T = new Point(tx, ty, tz);
            //string posl = cx + " " + cy + " " + cz + " " + width + " " + height;
            Point Tc = new Point(tx,ty,tz);
            Point Cc = new Point(cx,cy,cz);
            try
            {
                double m = Math.Sqrt(C.getx() * C.getx() + C.getz() * C.getz() + C.gety() * C.gety());
                cosX = (C.getz() / (float)m);
                sinX = ((float)Math.Sqrt(C.getx() * C.getx() + C.gety() * C.gety()) / (float)m);
            }
            catch { sinX = 0; cosX = 1; }

            try
            {
                double mm = Math.Sqrt(C.getx() * C.getx() + C.gety() * C.gety());

                sinZ = (C.gety() / (float)mm);
                cosZ = (C.getx() / (float)mm);
            }
            catch { sinZ = 0; cosZ = 1; }

            //textBox1.Text = "sinx=" + sinX.ToString() + ", cosx=" + cosX.ToString() + ", sinZ=" + sinZ.ToString() + ", cosZ=" + cosZ.ToString();
            //serviceInitOrt(posl);
            //serviceInitComplex(posl);

            
            X0.setx(len); X0.sety(0);   X0.setz(0);
            X1.setx(-len);X1.sety(0);   X1.setz(0);
            Y0.setx(0);   Y0.sety(len); Y0.setz(0);
            Y1.setx(0);   Y1.sety(-len);Y1.setz(0);
            Z0.setx(0);   Z0.sety(0);   Z0.setz(len);
            Z1.setx(0);   Z1.sety(0);   Z1.setz(-len);

            T1.setx(T.getx()); T1.sety(T.gety());   T1.setz(0);
            T2.setx(T.getx());T2.sety(0);   T2.setz(T.getz());
            T3.setx(0); T3.sety(T.gety());   T3.setz(T.getz());
            TX.setx(T.getx());TX.sety(0);   TX.setz(0);
            TY.setx(0); TY.sety(T.gety());   TY.setz(0);
            TZ.setx(0);TZ.sety(0);   TZ.setz(T.getz());

            float[,] rz = new float[,] {{sinZ,cosZ,0,0},{-cosZ,sinZ,0,0},{0,0,1,0},{0,0,0,1}};
            Matric rrz = new Matric(4, 4, rz);
            float[,] rx = new float[,] {{1,0,0,0},{0,cosX,sinX,0},{0,-sinX,cosX,0},{0,0,0,1}};
            Matric rrx = new Matric(4, 4, rx);
            float[,] tt = new float[,] {{1,0,0,0},{0,1,0,0},{0,0,1,0},{O.getx(),O.gety(),0,1}};
            Matric t = new Matric(4, 4, tt);

            T = ((T.umnog(rrz)).umnog(rrx)).umnog(t);
            TX= ((TX.umnog(rrz)).umnog(rrx)).umnog(t);
            TY= ((TY.umnog(rrz)).umnog(rrx)).umnog(t);
            TZ= ((TZ.umnog(rrz)).umnog(rrx)).umnog(t);
            T1= ((T1.umnog(rrz)).umnog(rrx)).umnog(t);
            T2= ((T2.umnog(rrz)).umnog(rrx)).umnog(t);
            T3= ((T3.umnog(rrz)).umnog(rrx)).umnog(t);

            X0 = ((X0.umnog(rrz)).umnog(rrx)).umnog(t);
            X1 = ((X1.umnog(rrz)).umnog(rrx)).umnog(t);
            Y0 = ((Y0.umnog(rrz)).umnog(rrx)).umnog(t);
            Y1 = ((Y1.umnog(rrz)).umnog(rrx)).umnog(t);
            Z0 = ((Z0.umnog(rrz)).umnog(rrx)).umnog(t);
            Z1 = ((Z1.umnog(rrz)).umnog(rrx)).umnog(t);

            OX.X1 = X0.getx(); OX.Y1 = X0.gety(); OX.X2 = X1.getx(); OX.Y2 = X1.gety();
            OY.X1 = Y0.getx(); OY.Y1 = Y0.gety(); OY.X2 = Y1.getx(); OY.Y2 = Y1.gety();
            OZ.X1 = Z0.getx(); OZ.Y1 = Z0.gety(); OZ.X2 = Z1.getx(); OZ.Y2 = Z1.gety();
            TOXt.X = OX.X1+2;  TOXt.Y = OX.Y1+2;
            TOYt.X = OY.X1 + 2; TOYt.Y = OY.Y1 + 2;
            TOZt.X = OZ.X1 + 2; TOZt.Y = OZ.Y1 + 2;

            transformT.X = T.getx();
            transformT.Y = T.gety();
            TTt.X = T.getx(); TTt.Y = T.gety();

            transformTX.X = TX.getx();
            transformTX.Y = TX.gety();
            TTXt.X = TX.getx(); TTXt.Y = TX.gety();
            transformTY.X = TY.getx();
            transformTY.Y = TY.gety();
            TTYt.X = TY.getx(); TTYt.Y = TY.gety();
            transformTZ.X = TZ.getx();
            transformTZ.Y = TZ.gety();
            TTZt.X = TZ.getx(); TTZt.Y = TZ.gety();

            transformT1.X = T1.getx();
            transformT1.Y = T1.gety();
            TT11t.X = T1.getx(); TT11t.Y = T1.gety();
            transformT2.X = T2.getx();
            transformT2.Y = T2.gety();
            TT22t.X = T2.getx(); TT22t.Y = T2.gety();
            transformT3.X = T3.getx();
            transformT3.Y = T3.gety();
            TT33t.X = T3.getx(); TT33t.Y = T3.gety();

            LT1.X1 = T.getx();   LT1.Y1 = T.gety();
            LT1.X2 = T1.getx();  LT1.Y2 = T1.gety();
            
            LT2.X1 = T.getx();   LT2.Y1 = T.gety();
            LT2.X2 = T2.getx();  LT2.Y2 = T2.gety();

            LT3.X1 = T.getx();   LT3.Y1 = T.gety();
            LT3.X2 = T3.getx();  LT3.Y2 = T3.gety();
            
            LT1X.X1 = T1.getx();  LT1X.Y1 = T1.gety();
            LT1X.X2 = TX.getx();  LT1X.Y2 = TX.gety();
            LT2X.X1 = T1.getx();  LT2X.Y1 = T1.gety();
            LT2X.X2 = TY.getx();  LT2X.Y2 = TY.gety();

            LT1Y.X1 = T2.getx();  LT1Y.Y1 = T2.gety();
            LT1Y.X2 = TZ.getx();  LT1Y.Y2 = TZ.gety();
            LT2Y.X1 = T2.getx();  LT2Y.Y1 = T2.gety();
            LT2Y.X2 = TX.getx();  LT2Y.Y2 = TX.gety();

            LT1Z.X1 = T3.getx();  LT1Z.Y1 = T3.gety();
            LT1Z.X2 = TY.getx();  LT1Z.Y2 = TY.gety();
            LT2Z.X1 = T3.getx();  LT2Z.Y1 = T3.gety();
            LT2Z.X2 = TZ.getx();  LT2Z.Y2 = TZ.gety();

            double wc = canvas2.Width;
            double hc = canvas2.Height;
            Oc.setx((float)wc / 2);
            Oc.sety((float)hc / 2);
            
            //complex
            X0c.setx(len); X0c.sety(0); X0c.setz(0);
            X1c.setx(-len); X1c.sety(0); X1c.setz(0);
            Z0c.setx(0); Z0c.sety(len); Z0c.setz(0);
            Z1c.setx(0); Z1c.sety(-len); Z1c.setz(0);

            T1c.setx(Oc.getx() - Tc.getx());
            T1c.sety(Oc.gety() + Tc.gety());
            TT1t.X = T1c.getx(); TT1t.Y = T1c.gety();
            T2c.setx(Oc.getx() - Tc.getx());
            T2c.sety(Oc.gety() - Tc.getz());
            TT2t.X = T2c.getx(); TT2t.Y = T2c.gety();
            T3c.setx(Oc.getx() + Tc.gety());
            T3c.sety(Oc.gety() - Tc.getz());
            TT3t.X = T3c.getx(); TT3t.Y = T3c.gety();

            C1c.setx(Oc.getx() - Cc.getx());
            C1c.sety(Oc.gety() + Cc.gety());
            TC1t.X = C1c.getx(); TC1t.Y = C1c.gety();
            C2c.setx(Oc.getx() - Cc.getx());
            C2c.sety(Oc.gety() - Cc.getz());
            TC2t.X = C2c.getx(); TC2t.Y = C2c.gety();
            C3c.setx(Oc.getx() + Cc.gety());
            C3c.sety(Oc.gety() - Cc.getz());
            TC3t.X = C3c.getx(); TC3t.Y = C3c.gety();
            //(O.getx() - t.getx()),(O.gety() - t.gety())

            OXc.X1 = Oc.getx() - X0c.getx(); OXc.Y1 = Oc.gety() - X0c.gety();
            OXc.X2 = Oc.getx() - X1c.getx(); OXc.Y2 = Oc.gety() - X1c.gety();

            CXt.X = OXc.X1 + 2;
            CXt.Y = OXc.Y1 + 2;

            OZc.X1 = Oc.getx() - Z0c.getx(); OZc.Y1 = Oc.gety() - Z0c.gety();
            OZc.X2 = Oc.getx() - Z1c.getx(); OZc.Y2 = Oc.gety() - Z1c.gety();

            CZt.X = OZc.X1 + 2;
            CZt.Y = OZc.Y1 + 2;
            
            LC1.X1 = T1c.getx(); LC1.Y1 = T1c.gety();
            LC1.X2 = T2c.getx(); LC1.Y2 = T2c.gety();
            LC2.X1 = T2c.getx(); LC2.Y1 = T2c.gety();
            LC2.X2 = T3c.getx(); LC2.Y2 = T3c.gety();
            LC21.X1 = T3c.getx(); LC21.Y1 = T3c.gety();
            LC21.X2 = T3c.getx(); LC21.Y2 = Oc.gety();

            LC3.X1 = T3c.getx(); LC3.Y1 = Oc.gety();
            LC3.X2 = Oc.getx(); LC3.Y2 = T1c.gety();
            LC4.X1 = Oc.getx(); LC4.Y1 = T1c.gety();
            LC4.X2 = T1c.getx(); LC4.Y2 = T1c.gety();

            LC5.X1 = C1c.getx(); LC5.Y1 = C1c.gety();
            LC5.X2 = C2c.getx(); LC5.Y2 = C2c.gety();
            LC6.X1 = C2c.getx(); LC6.Y1 = C2c.gety();
            LC6.X2 = C3c.getx(); LC6.Y2 = C3c.gety();
            LC7.X1 = C3c.getx(); LC7.Y1 = C3c.gety();
            LC7.X2 = C3c.getx(); LC7.Y2 = Oc.gety();
            LC8.X1 = C3c.getx(); LC8.Y1 = Oc.gety();
            LC8.X2 = Oc.getx(); LC8.Y2 = C1c.gety();
            LC9.X1 = Oc.getx(); LC9.Y1 = C1c.gety();
            LC9.X2 = C1c.getx(); LC9.Y2 = C1c.gety();

            transformT1c.X = T1c.getx();
            transformT1c.Y = T1c.gety();
            transformT2c.X = T2c.getx();
            transformT2c.Y = T2c.gety();
            transformT3c.X = T3c.getx();
            transformT3c.Y = T3c.gety();

            transformC1c.X = C1c.getx();
            transformC1c.Y = C1c.gety();
            transformC2c.X = C2c.getx();
            transformC2c.Y = C2c.gety();
            transformC3c.X = C3c.getx();
            transformC3c.Y = C3c.gety();

            

        }

        public MainPage()
        {
            InitializeComponent();
            slider1.Value = 50; slider2.Value = 50; slider3.Value = 50;
            slider4.Value = 50; slider5.Value = 50; slider6.Value = 50;
        }

        private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //Slider sldx = (Slider)sender;
            int cx1 = Convert.ToInt32(slider1.Value);
            //y_ch = yy.ToString();
            label1.Content = "X = " + cx1.ToString();
            change();
            //string sendXYZ = x_ch + " " + y_ch + " " + z_ch + " " + sizeW + " " + sizeH;
            //serviceInitOrt(sendXYZ);
            //serviceInitComplex(sendXYZ);
        }

        private void slider2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int cy1 = Convert.ToInt32(slider2.Value);
            //y_ch = yy.ToString();
            label2.Content = "Y = " + cy1.ToString();
            change();
        }

        private void slider3_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int cz1 = Convert.ToInt32(slider3.Value);
            //y_ch = yy.ToString();
            label3.Content = "Z = " + cz1.ToString();
            change();
        }

        private void slider4_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int tx1 = Convert.ToInt32(slider4.Value);
            //y_ch = yy.ToString();
            label4.Content = "X = " + tx1.ToString();
            change();
        }

        private void slider5_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int ty1 = Convert.ToInt32(slider5.Value);
            //y_ch = yy.ToString();
            label5.Content = "Y = " + ty1.ToString();
            change();
        }

        private void slider6_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int tz1 = Convert.ToInt32(slider6.Value);
            //y_ch = yy.ToString();
            label6.Content = "Z = " + tz1.ToString();
            change();
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Browser.HtmlPage.Window.Navigate(new Uri(System.Windows.Browser.HtmlPage.Document.DocumentUri.AbsoluteUri.Replace(System.Windows.Browser.HtmlPage.Document.DocumentUri.AbsolutePath, "/Comeformaspx.aspx")));
        }
    }
}
