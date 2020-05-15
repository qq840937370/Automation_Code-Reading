using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automation_CodeReadingUI
{
    public partial class UI_History_Scenario2 : Form
    {
        public UI_History_Scenario2()
        {
            InitializeComponent();
        }

        private void UI_History_Scenario2_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“history_DataSet.Used”中。您可以根据需要移动或删除它。
            this.usedTableAdapter.Fill(this.history_DataSet.Used);

        }
    }
}
