package contacts;

import java.util.List;
import org.springframework.data.neo4j.repository.GraphRepository;

/**
 * Repository that uses the Spring Data services such as automatic implementation of the below functions
 * @author stuartm
 */
public interface ContactRepository extends GraphRepository<Contact>
{
    Contact findByFirstName(String firstName);
    List<Contact> findByTeammatesFirstName(String firstName);
}
