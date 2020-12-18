using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    public class Day18 : Solver
    {
        string[] expressions;

        public Day18(string input)
        {
            expressions = input.Split("\r\n");
        }


        public override long SolvePart1()
        {
            return expressions.Sum(e => EvaluateExpressionWithLeftToRightRule(e));
        }

        public override long SolvePart2()
        {
            return expressions.Sum(e => EvaluateExpressionWithSumPrecedenceRule(e));
        }


        public static long EvaluateExpressionWithLeftToRightRule(string expression)
            => EvaluateExpression(EvaluateExpressionWithLeftToRightRule, ApplyLeftToRightRule, expression);

        public static long EvaluateExpressionWithSumPrecedenceRule(string expression)
            => EvaluateExpression(EvaluateExpressionWithSumPrecedenceRule, ApplySumPrecedenceRule, expression);

        private static long EvaluateExpression(Func<string, long> evaluatingExpressionStrategy, Func<string, long> operandsPrecedenceRule, string expression)
        {
            if (expression.Contains('('))
            {
                int indexOfInitialBracket = expression.IndexOf('(');
                int indexOfFinalBracket = GetFinalBracketIndex(expression, indexOfInitialBracket);

                string previousPart = expression.Substring(0, indexOfInitialBracket);
                long evaluatedExpression = evaluatingExpressionStrategy(expression.Substring(indexOfInitialBracket + 1, indexOfFinalBracket - indexOfInitialBracket - 1));
                string nextPart = expression.Substring(indexOfFinalBracket + 1);

                return evaluatingExpressionStrategy(previousPart + evaluatedExpression + nextPart);
            }

            if (expression.Contains('+') || expression.Contains('*'))
            {
                return operandsPrecedenceRule(expression);
            }

            return Convert.ToInt64(expression.Trim());


            int GetFinalBracketIndex(string expression, int indexOfInitialBracket)
            {
                int numberOfOpenBrackets = 1;
                int numberOfClosedBrackets = 0;
                int currentPos = indexOfInitialBracket + 1;

                while (numberOfOpenBrackets != numberOfClosedBrackets)
                {
                    if (expression[currentPos] == '(')
                    {
                        numberOfOpenBrackets++;
                    }
                    else if (expression[currentPos] == ')')
                    {
                        numberOfClosedBrackets++;
                    }

                    currentPos++;
                }

                return currentPos - 1;
            }
        }


        private static long ApplyLeftToRightRule(string expression)
        {
            int indexOfThirdBlank = GetThirdBlankIndex(expression);

            if (indexOfThirdBlank == -1)
            {
                return EvaluateExpressionWithLeftToRightRule(ExecuteOperation(expression).ToString());
            }
            else
            {
                string firstOperation = expression.Substring(0, indexOfThirdBlank);
                string restOfExpression = expression.Substring(indexOfThirdBlank + 1);
                return EvaluateExpressionWithLeftToRightRule(ExecuteOperation(firstOperation) + " " + restOfExpression);
            }


            int GetThirdBlankIndex(string expression)
            {
                int indexOfFirstBlank = expression.IndexOf(' ');
                int indexOfSecondBlank = expression.IndexOf(' ', indexOfFirstBlank + 1);
                return expression.IndexOf(' ', indexOfSecondBlank + 1);
            }
        }

        private static long ApplySumPrecedenceRule(string expression)
        {
            if (expression.Contains('+'))
            {
                int indexOfFirstSum = expression.IndexOf('+');
                int indextOfFirstOperand = GetFirstOperandIndex(indexOfFirstSum);
                int indexOfSecondBlankAfterSum = GetSecondBlankAfterSum(expression, indexOfFirstSum);

                string previousPart = indextOfFirstOperand == 0 ? "" : expression.Substring(0, indextOfFirstOperand - 1) + " ";
                string firstSum, restOfExpression;
                if (indexOfSecondBlankAfterSum == -1)
                {
                    firstSum = expression.Substring(indextOfFirstOperand);
                    restOfExpression = "";
                }
                else
                {
                    firstSum = expression.Substring(indextOfFirstOperand, indexOfSecondBlankAfterSum - indextOfFirstOperand);
                    restOfExpression = expression.Substring(indexOfSecondBlankAfterSum);
                }

                return EvaluateExpressionWithSumPrecedenceRule(previousPart + ExecuteOperation(firstSum) + restOfExpression);
            }
            else
            {
                return ApplyLeftToRightRule(expression);
            }


            int GetFirstOperandIndex(int sumIndex)
            {
                string aux = expression.Substring(0, sumIndex).TrimEnd();
                int lastBlankIndex = aux.LastIndexOf(' ');

                return lastBlankIndex + 1;
            }

            int GetSecondBlankAfterSum(string expression, int indexOfFirstSum)
            {
                int indexOfFirstBlank = expression.IndexOf(' ', indexOfFirstSum);
                return expression.IndexOf(' ', indexOfFirstBlank + 1);
            }
        }


        private static long ExecuteOperation(string operation)
        {
            operation = operation.TrimEnd().TrimStart();
            int indexOfFirstOperator = operation.IndexOfAny(new char[] { '+', '*' });
            char firstOperator = operation[indexOfFirstOperator];

            if (firstOperator == '+')
            {
                string[] operands = operation.Split(" + ");

                return Convert.ToInt64(operands[0]) + Convert.ToInt64(operands[1]);
            }
            else
            {
                string[] operands = operation.Split(" * ");

                return Convert.ToInt64(operands[0]) * Convert.ToInt64(operands[1]);
            }
        }
    }
}