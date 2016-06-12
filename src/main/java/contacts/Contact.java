package contacts;

import java.util.Collections;
import java.util.HashSet;
import java.util.Optional;
import java.util.Set;
import java.util.stream.Collectors;
import org.neo4j.graphdb.Direction;
import org.springframework.data.neo4j.annotation.Fetch;
import org.springframework.data.neo4j.annotation.GraphId;
import org.springframework.data.neo4j.annotation.NodeEntity;
import org.springframework.data.neo4j.annotation.RelatedTo;

@NodeEntity
public class Contact {

    @GraphId
    private Long id;
    private String firstName;
    private String lastName;
    private String phoneNumber;
    private String emailAddress;
    
    @RelatedTo(type="TEAMMATE", direction=Direction.BOTH)
    public @Fetch Set<Contact> teammates;
    
    /**
     * Neo4j requires a no-arg constructor much like JPA
     */
    public Contact(){}

    Contact(String firstname) {
        this.firstName = firstname;
                
    }

    public void setId(Long id) {
        this.id = id;
    }

    public Long getId() {
        return id;
    }
    
    public void worksWith(Contact contact) {
        if (teammates == null) {
            teammates = new HashSet<>();
        }
        teammates.add(contact);
    }
    
    public String toString() {
        return this.firstName + "'s teammates => " +
            Optional.ofNullable(this.teammates)
                .orElse(Collections.emptySet())
                .stream()
                    .map(contact -> contact.getFirstName())
                    .collect(Collectors.toList());
    }

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    public String getFirstName() {
        return firstName;
    }

    public void setLastName(String lastName) {
        this.lastName = lastName;
    }

    public String getLastName() {
        return lastName;
    }

    public void setPhoneNumber(String phoneNumber) {
        this.phoneNumber = phoneNumber;
    }

    public String getPhoneNumber() {
        return phoneNumber;
    }

    public void setEmailAddress(String emailAddress) {
        this.emailAddress = emailAddress;
    }

    public String getEmailAddress() {
        return emailAddress;
    }
}
