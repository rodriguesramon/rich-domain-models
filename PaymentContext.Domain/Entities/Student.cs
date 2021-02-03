using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private IList<Subscription> _subscriptons;
        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscriptons = new List<Subscription>();     

            AddNotifications(name, document, email);      
        }
       
        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get {return _subscriptons.ToArray(); }}

        public void AddSubscription(Subscription subscription)
        {   
            var hasSubscriptionActive = false;
            foreach(var sub in Subscriptions)
            {
                sub.Inactivate();            
                hasSubscriptionActive = true;
            }

            AddNotifications(new Contract()
            .Requires()
            .IsFalse(hasSubscriptionActive, "Student.Subscription", "Você já tem uma assinatura ativa")
            );
        }
    }
}