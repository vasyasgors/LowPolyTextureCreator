using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using Color = System.Drawing.Color;

namespace LowPolyTextureCreater
{
    public class CustomMenuRenderer : ToolStripProfessionalRenderer
    {
        public CustomMenuRenderer() : base(new CustomColorTable()) { }
    }

    public class CustomColorTable : ProfessionalColorTable
    {

        // Обовдка элементов выпадающего списка
        public override Color MenuItemBorder => Color.FromArgb(71, 114, 179);

        // Обводка всего меню при открытии выпадающего списка
        public override Color MenuBorder => Color.FromArgb(24, 24, 24);

        // Обводка выпадающего списка
        public override Color ToolStripDropDownBackground => Color.FromArgb(36, 36, 36);

        // Фон элементов выпадающего списка
        public override Color MenuItemSelected => Color.FromArgb(71, 114, 179); 

        // Фон кнопок меню при наведении
        public override Color MenuItemSelectedGradientBegin => Color.FromArgb(58, 89, 134);
        public override Color MenuItemSelectedGradientEnd => Color.FromArgb(58, 89, 134);

        // Фон кнопки меню при открытом списке
        public override Color MenuItemPressedGradientBegin => Color.FromArgb(58, 89, 134);

        public override Color MenuItemPressedGradientMiddle => Color.FromArgb(58, 89, 134);

        public override Color MenuItemPressedGradientEnd => Color.FromArgb(58, 89, 134);



  




    }
}
