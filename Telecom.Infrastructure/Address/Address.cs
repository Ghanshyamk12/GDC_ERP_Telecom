using System;
using System.Collections.Generic;
using System.Text;
using Telecom.Application.Interfaces;
using Telecom.Application.Procedure;
using Telecom.Application.ViewModels;

namespace Telecom.Infrastructure.Address
{
    public class Address : IAddress
    {
        FindAddressData findAddress = new FindAddressData();

        public IList<AddressDetail> FindAddress(AddressDetail Address, int type, string dbName)
        {
            if (!String.IsNullOrEmpty(Address.AddressNbr.ToString()))
            {
                return findAddress.FindAddressNbr(Address.AddressNbr.ToString(), type, "spFindAddressNbr", dbName);
            }
            else if (!String.IsNullOrEmpty(Address.Name))
            {
                return findAddress.FindAddressNbr(Address.Name.ToString(), type, "spFindAddressName", dbName);
            }
            else if (!String.IsNullOrEmpty(Address.Street))
            {
                return findAddress.FindAddressNbr(Address.Street.ToString(), type, "spFindAddressStreet", dbName);
            }
            else if (!String.IsNullOrEmpty(Address.Zipcode.ToString()))
            {
                return findAddress.FindAddressNbr(Address.Zipcode.ToString(), type, "spFindAddressZipCode", dbName);
            }
            else if (!String.IsNullOrEmpty(Address.Zipsuffix.ToString()))
            {
                return findAddress.FindAddressNbr(Address.Zipsuffix.ToString(), type, "spFindAddressZipSuffix", dbName);
            }
            else if (!string.IsNullOrEmpty(Address.City))
            {
                return findAddress.FindAddressNbr(Address.City.ToString(), type, "spFindAddressCity", dbName);
            }
            else if (!String.IsNullOrEmpty(Address.Remark))
            {
                return findAddress.FindAddressNbr(Address.Remark.ToString(), type, "spFindAddressRemark", dbName);
            }
            else
            {

            }
            return null;
        }
    }
}
