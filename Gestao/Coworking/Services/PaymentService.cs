using API.Models;
using API.Repositories;

public class PaymentService {
    public class PaymentService(){
    };

    public Payment[] getAll(){
        return PaymentRepositories.getAll();
    }

    public Payment create(Payment payment){
        PaymentRepositories.create(payment);

        return payment;
    }

    public Payment update(string id){
        Payment paymentToUpdate = PaymentRepositories.getById(id);
        for(change){
            paymentToUpdate.change = change; //corrigir
        };
        return PaymentRepositories.updateById(id, payment)
    }

    public void delete(string id){
        PaymentRepositories.deleteById(id);
    }

    public Payment getById(string id){
        return PaymentRepositories.getById(id);
    }
}