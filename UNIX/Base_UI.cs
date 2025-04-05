using MelonLoader.TinyJSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UNIX.Base_UI;

namespace UNIX
{
    internal class Base_UI
    {
        internal struct Size
        {
            public int width { get; set; }
            public int height { get; set; }

            public Size(int w, int h)
            {
                this.width = w;
                this.height = h;
            }
        }

        public static void Window(string name, Rect r)
        {
            Base_UI.currentWindowPosition = r;
            GUI.Box(Base_UI.currentWindowPosition, name, GUISkin.current.window);
        }

        public static void Space()
        {
            //Base_UI.currentButtonPosition.y = Base_UI.currentButtonPosition.y + (float)Base_UI.lastSize.height + 5f;
        }

        public static bool Button(string Name, Size size, float y)
        {
            float x = Base_UI.currentWindowPosition.x + 10f;
            y = 30 * y;
            y = Base_UI.currentWindowPosition.y + 20f + y;

            float w = size.width;
            float h = size.height;

            Rect currentButtonPosition = new Rect(x, y, w, h);
            bool flag = currentButtonPosition.Contains(new Vector2(Input.mousePosition.x, (float)Screen.height - Input.mousePosition.y));

            if (Event.current.type == EventType.MouseDown)
            {
                return Input.GetMouseButtonDown(0) && flag;
            }
            GUI.Button(currentButtonPosition, Name);
            return Input.GetMouseButtonDown(0) && flag;
        }

        public static void TextInput(Size size, float y)
        {
            float x = Base_UI.currentWindowPosition.x + 10f;
            if (y == 1f)
            {
                y = Base_UI.currentWindowPosition.y + 20f;
            }
            else
            {
                y = 30f * y - 30f;
                y = Base_UI.currentWindowPosition.y + 20f + y;
            }

            float w = size.width;
            float h = size.height;

            currentTextPosition = new Rect(x, y, w, h);
            GUI.Box(currentTextPosition, ToEdit);

            if (Input.GetKey(KeyCode.Space))
            {
                foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(KeyCode.Delete))
                    {
                        ToEdit = "";
                    }

                    if (Input.GetKeyDown(keyCode))
                    {
                        if (keyCode != KeyCode.Space | keyCode != KeyCode.Delete)
                        {
                            ToEdit += keyCode;
                            UNIX_Log.Logger.SendLog(UNIX_Log.Logger.Level.WARNING, ToEdit);
                        }
                    }
                }
            }
        }

        private static Rect currentWindowPosition;
        public static Rect currentButtonPosition;
        public static Rect currentTextPosition;
        public static Size NormalButtonSize = new Size(100, 30);
        public static Size BigButtonSize = new Size(150, 30);
        public static Size NormalTextSize = new Size(100, 30);
        public static string ToEdit = "Enter...";
        public static bool Entryyy = false;
        private static Size lastSize;
    }
}