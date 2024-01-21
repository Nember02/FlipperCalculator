using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class RotatedLabel : Label
{
    private int rotateAngle = 0;

    [DefaultValue(0)]
    public int RotateAngle
    {
        get { return rotateAngle; }
        set
        {
            rotateAngle = value % 360;
            Invalidate();
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        using (Matrix matrix = new Matrix())
        {
            matrix.RotateAt(rotateAngle, new Point(Width / 2, Height / 2));

            using (Font rotatedFont = new Font(Font.FontFamily, Font.Size, Font.Style, Font.Unit))
            {
                e.Graphics.Transform = matrix;
                e.Graphics.DrawString(Text, rotatedFont, new SolidBrush(ForeColor), ClientRectangle);
            }
        }
    }
}
