using System;
using System.Threading;

namespace WindowsFormsApp1.Services
{
    class Modbus
    {
        private readonly string _address;
        private readonly string _port;

        //для моделирования успешности соединения
        private readonly Random _random = new Random();

        //ctor
        public Modbus(string address, string port)
        {
            if (string.IsNullOrEmpty(address))
                throw new System.ArgumentException(nameof(address));
            if (string.IsNullOrEmpty(port))
                throw new System.ArgumentException(nameof(port));
            _address = address;
            _port = port;
        }

        public bool OpenTCP()
        {
            int num = _random.Next(1, 10);

            Thread.Sleep(1000);

            num = _random.Next(1, 10);

            return num % 2 == 0;
        }

        public bool CloseTCP()
        {
            Thread.Sleep(500);
            return true;
        }
    }
}
