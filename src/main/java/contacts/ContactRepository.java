package contacts;

import java.util.List;
import org.springframework.data.repository.CrudRepository;

public interface ContactRepository extends CrudRepository<Contact, String> 
{
    Contact findByFirstName(String firstName);
    List<Contact> findByTeammatesFirstName(String firstName);
}
