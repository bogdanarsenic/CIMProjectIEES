using FTN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Client
{
    public class ResultHelper
    {

        public static ModelCode getLatestChild(ModelCode mc)
        {
            if (mc == ModelCode.TERMINAL_CONNECTNODE)
            {
                return ModelCode.CONNECTNODE;
            }

            if (mc == ModelCode.TERMINAL_CONDEQ)
            {
                return ModelCode.CONDUCTINGEQ;
            }

            if (mc == ModelCode.TERMINAL_TRANSEND)
            {
                return ModelCode.TRANSFORMEREND;
            }

            if (mc == ModelCode.CONDUCTINGEQ_TERMINALS)
            {
                return ModelCode.TERMINAL;
            }

            if (mc == ModelCode.CONNECTNODE_TERM)
            {
                return ModelCode.TERMINAL;
            }

            if (mc == ModelCode.TRANSFORMEREND_TERMINAL)
            {
                return ModelCode.TERMINAL;
            }

            if (mc == ModelCode.TRANSFORMEREND_RATIOTAPCH)
            {
                return ModelCode.RATTAPCHANGER;
            }

            if (mc == ModelCode.POWERTR_POWTRE)
            {
                return ModelCode.POWERTE;
            }

            if (mc == ModelCode.POWERTE_POWERTR)
            {
                return ModelCode.POWERTR;
            }

            if (mc == ModelCode.RATTAPCHANGER_TRANSEND)
            {
                return ModelCode.TRANSFORMEREND;
            }


            return ModelCode.IDOBJ;

        }
        public static void FillTextBoxExtentValues(TextBox richTextBox, List<ResourceDescription> result)
        {
            int cnt = 0;
            foreach (ResourceDescription rds in result)
            {
                richTextBox.AppendText($"Element {++cnt}:\n");
                foreach (Property p in rds.Properties)
                {
                    richTextBox.AppendText(p.Id + "=");
                    if (p.Type.ToString() == "Float")
                    {
                        richTextBox.AppendText(p.PropertyValue.FloatValue.ToString());
                    }

                    if (p.Type.ToString() == "String")
                    {
                        richTextBox.AppendText(p.PropertyValue.StringValue.ToString());
                    }

                    if (p.Type.ToString() == "Long")
                    {
                        richTextBox.AppendText(p.PropertyValue.LongValue.ToString());
                    }
                    if (p.Type.ToString() == "Reference")
                    {
                        string hexValue = p.PropertyValue.LongValue.ToString("X");
                        richTextBox.AppendText("ref " + "0x" + hexValue);
                    }

                    if (p.Type.ToString() == "Int64")
                    {
                        string hexValue = p.PropertyValue.LongValue.ToString("X");
                        richTextBox.AppendText("0x" + hexValue);
                    }

                    if (p.Type.ToString() == "ReferenceVector")
                    {
                        richTextBox.AppendText("\n");
                        if (p.PropertyValue.LongValues.Count > 0)
                        {
                            foreach (long val in p.PropertyValue.LongValues)
                            {
                                string hexValue = val.ToString("X");
                                richTextBox.AppendText("ref " + "0x" + hexValue);
                                richTextBox.AppendText("\n");
                            }
                        }
                        else
                        {
                            richTextBox.AppendText("ref 0x0");
                        }
                    }

                    if (p.Type.ToString() == "Int32")
                    {
                        richTextBox.AppendText(p.PropertyValue.LongValue.ToString());
                    }

                    if (p.Type.ToString() == "Bool")
                    {
                        richTextBox.AppendText(p.ToString());
                    }

                    if(p.Type.ToString()=="Enum")
                    {
                        string ph = Enum.GetName(typeof(PhaseCode), Convert.ToInt32(p.ToString()));
                        richTextBox.AppendText(ph);
                    }

                    richTextBox.AppendText("\n");
                }
                richTextBox.AppendText("\n\n");
            }
        }
        public static void FillTextBoxValues(TextBox richTextBox,ResourceDescription result)
        {
            foreach (Property p in result.Properties)
            {
                richTextBox.AppendText(p.Id + "=");
                if (p.Type.ToString() == "Float")
                {
                    richTextBox.AppendText(p.PropertyValue.FloatValue.ToString());
                }

                if (p.Type.ToString() == "String")
                {
                    richTextBox.AppendText(p.PropertyValue.StringValue.ToString());
                }

                if (p.Type.ToString() == "Long")
                {
                    richTextBox.AppendText(p.PropertyValue.LongValue.ToString());
                }
                if (p.Type.ToString() == "Reference")
                {
                    string hexValue = p.PropertyValue.LongValue.ToString("X");
                    richTextBox.AppendText("ref " + "0x" + hexValue);
                }

                if (p.Type.ToString() == "Int64")
                {
                    string hexValue = p.PropertyValue.LongValue.ToString("X");
                    richTextBox.AppendText("0x" + hexValue);
                }

                if (p.Type.ToString() == "ReferenceVector")
                {
                    richTextBox.AppendText("\n");
                    if (p.PropertyValue.LongValues.Count > 0)
                    {
                        foreach (long val in p.PropertyValue.LongValues)
                        {
                            string hexValue = val.ToString("X");
                            richTextBox.AppendText("ref " + "0x" + hexValue);
                            richTextBox.AppendText("\n");
                        }
                    }
                    else
                    {
                        richTextBox.AppendText("ref 0x0");
                    }
                }

                if (p.Type.ToString() == "Int32")
                {
                    richTextBox.AppendText(p.PropertyValue.LongValue.ToString());
                }

                if (p.Type.ToString() == "Bool")
                {
                    richTextBox.AppendText(p.ToString());
                }


                if (p.Type.ToString() == "Enum")
                {
                    string ph = Enum.GetName(typeof(PhaseCode), Convert.ToInt32(p.ToString()));
                    richTextBox.AppendText(ph);
                }


                richTextBox.AppendText("\n");
            }
            richTextBox.AppendText("\n\n");
        }

        
    }
}
