using System;
using System.Text.RegularExpressions;
using BLL.Interface.Services;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Entity of account holder.
    /// </summary>
    public class HolderEntity
    {
        #region Fields

        /// <summary>
        /// First name of account holder.
        /// </summary>
        private string firstName;

        /// <summary>
        /// Last name of account holder.
        /// </summary>
        private string lastName;

        /// <summary>
        /// Email of account holder.
        /// </summary>
        private string email;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HolderEntity"/> class with default values.
        /// </summary>
        public HolderEntity()
        {
            FirstName = "New";
            LastName = "Holder";
            Email = "Test@test.com";
            HolderNumber = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HolderEntity"/> class.
        /// </summary>
        /// <param name="firstName">First name of account holder.</param>
        /// <param name="lastName">Last name of account holder.</param>
        /// <param name="email">Email of account holder.</param>
        /// <param name="generator">Generator of holder's identification number.</param>
        public HolderEntity(string firstName, string lastName, string email, IHolderNumberGenerator generator = null)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            HolderNumber = generator == null ? Guid.NewGuid().ToString() : generator.GenerateHolderNumber();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the first name.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when the first name is incorrect.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the first name value is null.</exception>
        public string FirstName
        {
            get => firstName;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(value)} can not be null.");
                }

                Regex regex = new Regex(@"[A-Z]+[a-zA-Z]*");

                if (!regex.IsMatch(value))
                {
                    throw new ArgumentException($"{nameof(value)} is incorrect.");
                }

                firstName = value;
            }
        }

        /// <summary>
        /// Gets the last name.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when the last name is incorrect.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the last name value is null.</exception>
        public string LastName
        {
            get => lastName;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(value)} can not be null.");
                }

                Regex regex = new Regex(@"[A-Z]+[a-zA-Z]*");

                if (!regex.IsMatch(value))
                {
                    throw new ArgumentException($"{nameof(value)} is incorrect.");
                }

                lastName = value;
            }
        }

        /// <summary>
        /// Gets the email.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when the email is incorrect.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the email value is null.</exception>
        public string Email
        {
            get => email;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(value)} can not be null.");
                }

                Regex regex = new Regex(
                    @"([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})");

                if (!regex.IsMatch(value))
                {
                    throw new ArgumentException($"{nameof(value)} is incorrect.");
                }

                email = value;
            }
        }

        /// <summary>
        /// Gets holder's identification number.
        /// </summary>
        public string HolderNumber { get; set; }

        #endregion

        #region Formatting member

        public override string ToString()
        {
            return $"{nameof(FirstName)}: {FirstName}\n{nameof(LastName)}: {LastName}\n{nameof(Email)}: {Email}\n{nameof(HolderNumber)}: {HolderNumber}";
        }

        #endregion
    }
}