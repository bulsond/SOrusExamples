using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFormsProducts.Abstractions;
using WinFormsProducts.Models;

namespace WinFormsProducts
{
    public partial class MainForm : Form
    {
        //Товары на прилавке
        Dictionary<string, IProduct> _products;

        public MainForm()
        {
            InitializeComponent();

            //Данные по товарам
            LoadProducts();

            //установка привязок
            SetBindings();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Пример";
            //кнопки
            _buttonCalc.Click += ButtonCalc_Click;
            _buttonReset.Click += ButtonReset_Click;
        }

        //Создание коллекции продуктов
        private void LoadProducts()
        {
            _products = new Dictionary<string, IProduct>
            {
                { "apples", new Product("Яблоки", 76.25m) },
                { "plums", new Product("Сливы", 35.30m) },
                { "mandarins", new Product("Мандарины", 85.30m) },
                { "oranges", new Product("Апельсины", 105.40m) },
            };
        }

        //Установка привязок
        private void SetBindings()
        {
            //Яблоки
            //--надпись у чекбокса привязываем к названию товара
            _checkBoxApples.DataBindings.Add(nameof(CheckBox.Text), _products["apples"], nameof(IProduct.Name));
            //--текст лейбла привязываем к цене товара за кг.
            _labelApplePrice.DataBindings.Add(nameof(Label.Text), _products["apples"], nameof(IProduct.PricePerKg));
            //--текст текстбокса привязываем к весу товара
            _textBoxApples.DataBindings.Add(nameof(TextBox.Text), _products["apples"],
                nameof(IProduct.Weight), true, DataSourceUpdateMode.OnPropertyChanged);
            //--доступность текстбокса привязываем к включ. чекбокса
            _textBoxApples.DataBindings.Add(nameof(TextBox.Enabled), _checkBoxApples, nameof(CheckBox.Checked));

            //Сливы
            _checkBoxPlums.DataBindings.Add(nameof(CheckBox.Text), _products["plums"], nameof(IProduct.Name));
            _labelPlumsPrice.DataBindings.Add(nameof(Label.Text), _products["plums"], nameof(IProduct.PricePerKg));
            _textBoxPlums.DataBindings.Add(nameof(TextBox.Text), _products["plums"],
                nameof(IProduct.Weight), true, DataSourceUpdateMode.OnPropertyChanged);
            _textBoxPlums.DataBindings.Add(nameof(TextBox.Enabled), _checkBoxPlums, nameof(CheckBox.Checked));

            //Мандарины
            _checkBoxMandarins.DataBindings.Add(nameof(CheckBox.Text), _products["mandarins"], nameof(IProduct.Name));
            _labelMandarinsPrice.DataBindings.Add(nameof(Label.Text), _products["mandarins"], nameof(IProduct.PricePerKg));
            _textBoxMandarins.DataBindings.Add(nameof(TextBox.Text), _products["mandarins"],
                nameof(IProduct.Weight), true, DataSourceUpdateMode.OnPropertyChanged);
            _textBoxMandarins.DataBindings.Add(nameof(TextBox.Enabled), _checkBoxMandarins, nameof(CheckBox.Checked));

            //Апельсины
            _checkBoxOranges.DataBindings.Add(nameof(CheckBox.Text), _products["oranges"], nameof(IProduct.Name));
            _labelOrangesPrice.DataBindings.Add(nameof(Label.Text), _products["oranges"], nameof(IProduct.PricePerKg));
            _textBoxOranges.DataBindings.Add(nameof(TextBox.Text), _products["oranges"],
                nameof(IProduct.Weight), true, DataSourceUpdateMode.OnPropertyChanged);
            _textBoxOranges.DataBindings.Add(nameof(TextBox.Enabled), _checkBoxOranges, nameof(CheckBox.Checked));
        }

        //Кнопка "Итого"
        private void ButtonCalc_Click(object sender, EventArgs e)
        {
            //формируем список покупок
            List<IProduct> selectedProds = _products.Values
                                                .Where(p => p.Weight > 0)
                                                .Select(p => p.GetProductToCart())
                                                .ToList();

            //вычисляем итоговую стоимость
            decimal sum = selectedProds.Aggregate(0m, (acc, p) => acc + p.PriceInCart);

            //отображаем результаты
            ShowCart(selectedProds, sum);
        }

        //Кнопка "Сбросить"
        private void ButtonReset_Click(object sender, EventArgs e)
        {
            //итог
            _labelCartProducts.Text = String.Empty;
            //обнуляем вес у всех товаров
            _groupBoxProducts.Controls
                                    .OfType<TextBox>()
                                    .ToList()
                                    .ForEach(tb => tb.Text = "0");
            //выключаем чекбоксы
            _groupBoxProducts.Controls
                                    .OfType<CheckBox>()
                                    .ToList()
                                    .ForEach(c => c.Checked = false);
        }

        //Отображение итога
        private void ShowCart(List<IProduct> selectedProds, decimal sum)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Ваши покупки:");
            sb.AppendLine();

            //товары
            int count = 0;
            selectedProds.ForEach(p =>
                sb.AppendLine($"{++count}) {p.Name} ({p.Weight} кг.) {p.PriceInCart}"));
            //сумма
            sb.AppendLine();
            sb.AppendLine($"Итого: {sum}");

            _labelCartProducts.Text = sb.ToString();
        }
    }
}
