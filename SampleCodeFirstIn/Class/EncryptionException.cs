using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace SampleCodeFirstIn.Class
{
    public class EncryptionException : ApplicationException
    {
        public enum Code { UnidentifiedException, EncryptionFailure, DecryptionFailure, InvalidInputValues }



        /// <summary>

        /// Stores the method information for where the exceptino was thrown.

        /// </summary>

        private MethodBase currentMethod = null;



        /// <summary>

        /// Exception with provided error code.

        /// </summary>

        /// <param name="code"></param>

        public EncryptionException(Code code)

            : base(pi_GetErrorMessage(code))
        {

        }



        /// <summary>

        /// Exception with provided code and inner exception.

        /// </summary>

        /// <param name="code">Error code</param>

        /// <param name="InnerException">The containing exception</param>

        public EncryptionException(Code code, Exception InnerException)

            : base(pi_GetErrorMessage(code), InnerException)
        {

        }



        /// <summary>

        /// Exception with provided method

        /// </summary>

        /// <param name="code">Error code</param>

        /// <param name="CurrentMethod">The method where the exception was thrown.</param>

        public EncryptionException(Code code, MethodBase CurrentMethod)

            : base(pi_GetErrorMessage(code))
        {

            this.currentMethod = CurrentMethod;

        }



        /// <summary>

        /// Exception with provided code, method and inner exception.

        /// </summary>

        /// <param name="code">Error code</param>

        /// <param name="InnerException">The containing exception</param>

        /// <param name="CurrentMethod">The method where the exception was thrown.</param>

        public EncryptionException(Code code, Exception InnerException, MethodBase CurrentMethod)

            : base(pi_GetErrorMessage(code), InnerException)
        {

            this.currentMethod = CurrentMethod;

        }



        /// <summary>

        /// Gets the error message from the specified error code.

        /// </summary>

        /// <param name="code">Error code</param>

        /// <returns>Mapped error message.</returns>

        public static string pi_GetErrorMessage(Code code)
        {

            switch (code)
            {

                case Code.EncryptionFailure:

                    return "Unable to encrypt string against specified security key.";

                case Code.DecryptionFailure:

                    return "Unable to decrypt string against specified security key.";

                case Code.InvalidInputValues:

                    return "Input string or security key for MD5 cryptography is invalid.";

                default:

                case Code.UnidentifiedException:

                    return "An unidentified error has occurred.";

            }

        }
    }
}