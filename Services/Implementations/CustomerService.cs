﻿using System.Collections.Generic;
using System.Linq;
using NewProject_RealizedSale.Dtos.BaseDtos;
using NewProject_RealizedSale.Dtos.CreateUpdate;
using NewProject_RealizedSale.Dtos.Sorted;
using NewProject_RealizedSale.Models;
using NewProject_RealizedSale.Repositories;
using NewProject_RealizedSale.Services.Abstractions;

namespace NewProject_RealizedSale.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerService(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public CustomerDto GetCustomerByNameAndSurname(string name, string surname)
        {
            var customer = _customerRepository.GetCustomerByNameAndSurname(name, surname);

            var customerDTO = new CustomerDto
            {
                CustomerId = customer.Id,
                Name = customer.Name,
                Surname = customer.Surname,
                PhoneNumber = customer.PhoneNumber
            };

            return customerDTO;
        }

        public void CreateCustomer(CustomerDto createCustomer)
        {
            var customer = new Customer
            {
                Name = createCustomer.Name,
                Surname = createCustomer.Surname,
                PhoneNumber = createCustomer.PhoneNumber
            };

            _customerRepository.Create(customer);

            _customerRepository.Save();
        }

        public void UpdateCustomer(UpdateCustomerDto updateCustomer)
        {
            var customer = _customerRepository.Get(updateCustomer.CustomerId);

            customer.Name = updateCustomer.Name;
            customer.Surname = updateCustomer.Surname;
            customer.PhoneNumber = updateCustomer.PhoneNumber;

            _customerRepository.Save();
        }

        public IList<SortedCustomerDTO> GetSorted(string sortBy)
        {
            var customers = _customerRepository.GetAll();

            var unsortedCustomers = new List<SortedCustomerDTO>();

            foreach (var customer in customers)
            {
                var unsortedCustomer = new SortedCustomerDTO
                {
                    Name = customer.Name,
                    Surname = customer.Surname,
                    PhoneNumber = customer.PhoneNumber
                };

                unsortedCustomers.Add(unsortedCustomer);
            }

            var sortedCustomers = GetSortedCustomers(unsortedCustomers, sortBy);

            return sortedCustomers;
        }

        private IList<SortedCustomerDTO> GetSortedCustomers(IList<SortedCustomerDTO> unsortedCustomers, string sortBy)
        {
            // var sortedCustomers = new List<SortedCustomerDTO>();

            if (sortBy == "name")
            {
                unsortedCustomers = unsortedCustomers.OrderBy(c => c.Name).ToList();
            }
            else if (sortBy == "surname")
            {
                unsortedCustomers = unsortedCustomers.OrderBy(c => c.Surname).ToList();
            }

            return unsortedCustomers;
        }
    }
}