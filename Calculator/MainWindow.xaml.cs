﻿using System;
using System.Windows;

namespace Calculator
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //firstNumber儲存第一個數字 | secondNumber儲存第二個數字
        float firstNumber,secondNumber;
        int operators = -1;

        private void Add_Number(string _number)
        {
            if (txtNumber.Text == "0")
                txtNumber.Text = "";
            txtNumber.Text = txtNumber.Text + _number;
        }

        private void btnZero_Click(object sender, RoutedEventArgs e)
        {
            //只需要呼叫Add_Number函式，並且設定參數為數字0
            Add_Number("0");
        }

        private void btnOne_Click(object sender, RoutedEventArgs e)
        {
            Add_Number("1");
        }

        private void btnTwo_Click(object sender, RoutedEventArgs e)
        {
            Add_Number("2");
        }

        private void btnThree_Click(object sender, RoutedEventArgs e)
        {
            Add_Number("3");
        }

        private void btnFour_Click(object sender, RoutedEventArgs e)
        {
            Add_Number("4");
        }

        private void btnFive_Click(object sender, RoutedEventArgs e)
        {
            Add_Number("5");
        }

        private void btnSix_Click(object sender, RoutedEventArgs e)
        {
            Add_Number("6");
        }

        private void btnSeven_Click(object sender, RoutedEventArgs e)
        {
            Add_Number("7");
        }

        private void btnEight_Click(object sender, RoutedEventArgs e)
        {
            Add_Number("8");
        }

        private void btnNine_Click(object sender, RoutedEventArgs e)
        {
            Add_Number("9");
        }

        private void Select_Operator(int _operator)
        {
            //將輸入文字框轉換成浮點數，存入第一個數字的全域變數
            firstNumber = Convert.ToSingle(txtNumber.Text);
            //重新將輸入文字框重新設定為0
            txtNumber.Text = "0";
            operators = _operator;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Select_Operator(0);
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            Select_Operator(1);
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            Select_Operator(2);
        }

        private void btnDivide_Click(object sender, RoutedEventArgs e)
        {
            Select_Operator(3);
        }

        private void btnDot_Click(object sender, RoutedEventArgs e)
        {
            //確認輸入文字框中完全沒有小數點
            if (txtNumber.Text.Contains(".") == false)
                txtNumber.Text = txtNumber.Text + ".";
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtNumber.Text = "0";
            firstNumber = 0f;
            secondNumber = 0f;
            operators = -1;
        }

        private void btnRewind_Click(object sender, RoutedEventArgs e)
        {
            string txt = Convert.ToString(firstNumber);
            if (txt.Length > 0)
            {
                txtNumber.Text = txt.Substring(0, txt.Length - 1);
            }
            else
            {
                txtNumber.Text = "0";
            }
        }

        private void btnPercentage_Click(object sender, RoutedEventArgs e)
        {
            //將輸入文字框轉換成浮點數
            firstNumber = Convert.ToSingle(txtNumber.Text);
            firstNumber /= 100;
            txtNumber.Text = string.Format("{0:P2}", firstNumber);
        }

        private void btnEqual_Click(object sender, RoutedEventArgs e)
        {
            //宣告最後計算結果變數
            float finalResults = 0f;
            //將輸入文字框轉換成浮點數，存入第二個數字的全域變數
            secondNumber = Convert.ToSingle(txtNumber.Text);

            //依照四則運算符號的選擇，進行加減乘除
            switch (operators)
            {
                case 0:
                    finalResults = firstNumber + secondNumber;
                    break;
                case 1:
                    finalResults = firstNumber - secondNumber;
                    break;
                case 2:
                    finalResults = firstNumber * secondNumber;
                    break;
                case 3:
                    finalResults = firstNumber / secondNumber;
                    break;
            }

            //在輸入文字框中，顯示最後計算結果，並且轉換成格式化的字串內容
            txtNumber.Text = string.Format("{0:0.##########}", finalResults);

            //重置所有全域變數
            firstNumber = 0f;
            secondNumber = 0f;
            operators = -1;
        }
    }
}
