using System;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Views
{
    class DeviceTreeNode : TreeNode
    {
        public Device Device { get; private set; }

        public DeviceTreeNode(Device device)
        {
            Device = device ?? throw new ArgumentNullException(nameof(device));

            this.Text = $"IP:{Device.IpAddress}-Порт:{Device.Port}-Устройство:{Device.Name}";
        }
    }
}
