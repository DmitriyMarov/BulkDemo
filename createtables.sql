CREATE TABLE public.clients
(
    id serial NOT NULL,
	name varchar(255) NOT NULL,
    CONSTRAINT "PK_clients" PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE public.clients
    OWNER to postgres;
	
	
CREATE TABLE public.clientaffected
(
    id serial NOT NULL,
    client_id integer NOT NULL,
    CONSTRAINT "PK_clientaffected" PRIMARY KEY (id),
    CONSTRAINT "FK_ClientAffected_Clients" FOREIGN KEY (client_id)
        REFERENCES public.clients (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
)

TABLESPACE pg_default;

ALTER TABLE public.clientaffected
    OWNER to postgres;
	
	
CREATE TABLE public.entities
(
    id serial NOT NULL,
	name varchar(255) NOT NULL
)

TABLESPACE pg_default;

ALTER TABLE public.entities
    OWNER to postgres;
	
CREATE TABLE public.clienttoentities
(
    client_id integer NOT NULL,
    entity_id integer NOT NULL,
    excluded boolean NOT NULL,
    modifiedon timestamp without time zone NOT NULL,
    associationkind integer NOT NULL DEFAULT 0,
    CONSTRAINT "PK_ClientToEntities" PRIMARY KEY (client_id, entity_id),
    CONSTRAINT "FK_ClientToEntities_ClientId" FOREIGN KEY (client_id)
        REFERENCES public.clients (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE,
    CONSTRAINT "FK_ClientToEntities_EntityId" FOREIGN KEY (entity_id)
        REFERENCES public.entities (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
)

TABLESPACE pg_default;

ALTER TABLE public.clienttoentities
    OWNER to postgres