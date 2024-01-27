using System.Collections.Generic;

namespace BookstoreSystem
{
    class Account
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }
        public Dictionary<Book,int> CartInventory = new Dictionary<Book, int>();
        public Account() { }
        public Account(string Email, string Password, string PhoneNumber, string Username,
             string Address, int ZipCode)
        {
            this.Email = Email;
            this.Password = Password;
            this.PhoneNumber = PhoneNumber;
            this.Username = Username;
            this.Address = Address;
            this.ZipCode = ZipCode;
        }
        public Account(string Email, string Password,string PhoneNumber, string Username,
            string Address, int ZipCode, Dictionary<Book, int> CartInventory)
        {
            this.Email = Email;
            this.Password = Password;
            this.PhoneNumber = PhoneNumber;
            this.Username = Username;  
            this.Address = Address;
            this.ZipCode = ZipCode;
            this.CartInventory = CartInventory;
        }   
    }
}
