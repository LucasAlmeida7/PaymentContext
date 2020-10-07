using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private IList<Subscription> _subscriptions;

        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();

            AddNotifications(name, document, email);
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }

        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }

        public void AddSubscription(Subscription subscription){
            var hasSubscriptionsActive = false;
            foreach (var sub in Subscriptions)
            {
                if (sub.Active)
                    hasSubscriptionsActive = true;
            }

            AddNotifications(new Contract()
                .Requires()
                .IsFalse(hasSubscriptionsActive, nameof(Subscriptions), "O aluno já possui uma assinatura ativada.")
                .AreNotEquals(0, subscription.Payments.Count, nameof(Subscription), "A assinatura não possui pagamentos.")
            );

            _subscriptions.Add(subscription);
        }
    }
}