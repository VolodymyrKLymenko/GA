export class Law {
    id: string;
    number: string;
    currentPhase: LawPhase;
    title: string;
    type: string;
    uri: string;
    registrationConvocation: string;
    registrationSession: string;
    registrationDate: Date;
    rubric: string;
    subject: string;
    documents: Documents;
    executives: Executive[];
    mainExecutives: MainExecutive;
    initiators: Initiator[];
    passings: Commitment[];
    workOuts: Workouts;
}

export class LawPhase {
    date: Date;
    title: string;
}

export class Documents {
    source: SourceDocuments;
    workflow: WorkflowDocuments;
}

export class SourceDocuments {
    document: Document[] 
}

export class WorkflowDocuments {
    document: Document[] 
}

export class Document {
    date: Date;
    type: string;
    uri: string;
}

export class MainExecutive {
    executive: Executive;
}

export class Executive {
    person: Person;
    department: string;
}

export class Person {
    id: string;
    firstname: string;
    surname: string;
    patronymic: string;
}

export class Initiator {
    official: OfficialInitiator;
    outer: OuterInitiator;
}

export class OfficialInitiator {
    convocation: string;
    department: string;
    person: Person;
    post: string;
}

export class OuterInitiator {
    organization: string;
    person: Person;
    post: string;
}

export class Commitment {
    date: Date;
    title: string;
}

export class Workouts {
    date: Date;
    documentType: string;
    workOutCommittees: Workout[];
}

export class Workout {
    dateGot: Date;
    datePassed: Date;
    title: string;
}
