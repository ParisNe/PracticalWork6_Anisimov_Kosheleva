using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountNS
{
    /// <summary>
    /// Демонстрационный класс банковского счета.
    /// </summary>
    /// <remarks>
    /// Класс BankAccount предоставляет базовые операции для работы с банковским счетом:
    /// пополнение (Credit) и снятие средств (Debit). Класс также хранит информацию
    /// о владельце счета и текущем балансе.
    /// </remarks>
    public class BankAccount
    {
        private readonly string m_customerName;
        private double m_balance;

        private BankAccount() { }

        /// <summary>
        /// Конструктор класса BankAccount.
        /// </summary>
        /// <param name="customerName">Имя владельца счета.</param>
        /// <param name="balance">Начальный баланс счета.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Выбрасывается, когда начальный баланс меньше нуля.</exception>
        /// <value>Создает новый экземпляр банковского счета с указанным владельцем и начальным балансом.</value>
        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        /// <summary>
        /// Получает имя владельца счета.
        /// </summary>
        /// <value>Строка, содержащая имя владельца счета.</value>
        public string CustomerName
        {
            get { return m_customerName; }
        }

        /// <summary>
        /// Получает текущий баланс счета.
        /// </summary>
        /// <value>Число типа double, представляющее текущий баланс.</value>
        public double Balance
        {
            get { return m_balance; }
        }

        /// <summary>
        /// Снимает указанную сумму со счета.
        /// </summary>
        /// <param name="amount">Сумма для снятия.</param>
        /// <remarks>
        /// Метод проверяет, что сумма снятия не превышает текущий баланс
        /// и является положительным числом.
        /// </remarks>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Выбрасывается в двух случаях:
        /// <list type="bullet">
        /// <item><description>Если сумма снятия превышает текущий баланс.</description></item>
        /// <item><description>Если сумма снятия меньше нуля.</description></item>
        /// </list>
        /// </exception>
        /// <example>
        /// Пример использования метода Debit:
        /// <code>
        /// BankAccount account = new BankAccount("Иван Иванов", 1000.00);
        /// account.Debit(500.00); // Снимаем 500 рублей
        /// </code>
        /// </example>
        /// <seealso cref="Credit"/>
        public void Debit(double amount)
        {
            if (amount > m_balance)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            m_balance += amount;
        }
         
        /// <summary>
        /// Вносит указанную сумму на счет.
        /// </summary>
        /// <param name="amount">Сумма для внесения.</param>
        /// <remarks>
        /// Метод проверяет, что сумма внесения является положительным числом.
        /// </remarks>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Выбрасывается, если сумма внесения меньше нуля.
        /// </exception>
        /// <example>
        /// Пример использования метода Credit:
        /// <code>
        /// BankAccount account = new BankAccount("Иван Иванов", 1000.00);
        /// account.Credit(250.00); // Вносим 250 рублей
        /// </code>
        /// </example>
        /// <permission cref="System.Security.PermissionSet">Доступ к методу открыт для всех вызывающих кодов.</permission>
        /// <seealso cref="Debit"/>
        public void Credit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            m_balance += amount;
        }

        /// <summary>
        /// Точка входа в консольное приложение.
        /// </summary>
        /// <remarks>
        /// Демонстрирует использование методов класса BankAccount:
        /// создается счет с начальным балансом, выполняется пополнение,
        /// затем снятие средств, и выводится итоговый баланс.
        /// </remarks>
        /// <example>
        /// Данный метод создает счет для Mr. Roman Abramovich с балансом 11.99,
        /// добавляет 5.77, снимает 11.22 и выводит результат.
        /// </example>
        /// <param name="args">Аргументы командной строки (не используются).</param>
        /// <returns>Метод не возвращает значения (void).</returns>
        /// <seealso cref="BankAccount"/>
        public static void Main()
        {
            BankAccount ba = new BankAccount("Mr. Roman Abramovich", 11.99);

            ba.Credit(5.77);
            ba.Debit(11.22);
            Console.WriteLine("Current balance is ${0}", ba.Balance);
            Console.ReadLine();
        }
    }
}