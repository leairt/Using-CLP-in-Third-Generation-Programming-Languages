public class Meeting
{
    private String subject;

    private List<Person> attendees = new List<Person>();

    private Time time;

    Meeting(String subject, Time time) {
        this.subject = subject;
        this.time = time;
    }
}