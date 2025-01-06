namespace inter_sdk_library;

    public class SdkException : Exception {
        public Error Error;

        public SdkException(string message, Error error) : base(message) {
            Error = error;
        }
    }
