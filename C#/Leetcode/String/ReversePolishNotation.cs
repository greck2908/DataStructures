﻿using System;
using System.Collections.Generic;

namespace LeetcodeSolutions.String
{
    // RPN Wiki - https://en.wikipedia.org/wiki/Polish_notation
    // aka Postfix notation
    public class ReversePolishNotation
    {
        //static void Main(string[] args)
        //{
        //    ReversePolishNotation rpn = new ReversePolishNotation();

        //    string[] str1 = new string[] { "2", "1", "+", "3", "*" };
        //    Console.WriteLine($"Input: {str1},\tOutput: {rpn.EvalRPN(str1)},\tExpected:9");

        //    string[] str2 = new string[] { "4", "13", "5", "/", "+" };
        //    Console.WriteLine($"Input: {str2},\tOutput: {rpn.EvalRPN(str2)},\tExpected:6");

        //    string[] str3 = new string[] { "18" };
        //    Console.WriteLine($"Input: {str3},\tOutput: {rpn.EvalRPN(str3)},\tExpected:18");

        //    Console.ReadLine();
        //}

        Stack<int> operands = new Stack<int>();
        HashSet<string> validOperators = new HashSet<string>();

        public ReversePolishNotation()
        {
            validOperators.Add("+");
            validOperators.Add("-");
            validOperators.Add("*");
            validOperators.Add("/");
        }

        // Runtime : 188 ms
        // Tx = O(n) { n : Lenth of the string}
        // Sx = O(n) for storing in the stack
        public int EvalRPN(string[] tokens)
        {
            foreach (string token in tokens)
            {
                if (int.TryParse(token, out int operand))
                {
                    operands.Push(operand);
                }
                else if (validOperators.Contains(token))
                {
                    if (operands.Count > 1)
                    {
                        Compute(token);
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid RPN.");
                    }
                }
                else
                {
                    throw new InvalidOperationException("Invalid operator found.");
                }
            }

            return operands.Pop();
        }

        private void Compute(string op)
        {
            int operand2 = operands.Pop();
            int operand1 = operands.Pop();

            switch (op)
            {
                case "+":
                    operands.Push(operand1 + operand2);
                    break;
                case "-":
                    operands.Push(operand1 - operand2);
                    break;
                case "*":
                    operands.Push(operand1 * operand2);
                    break;
                case "/":
                    if (operand2 == 0)
                        throw new DivideByZeroException("Cannot perform / operation with denominator as 0.");

                    operands.Push(operand1 / operand2);
                    break;
            }
        }
    }
}
