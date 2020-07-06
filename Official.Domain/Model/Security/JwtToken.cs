using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Domain.Model.Security.ISecurityRepository
{
    public class JwtToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }

        private JwtToken()
        {
        }
        private static JwtToken instance = null;
        public static JwtToken Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JwtToken();
                }
                return instance;
            }
        }
    }
}
